using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Stmt;
using Grc.IR.Op;
using Grc.IR.Quads;
using Grc.Sem.SymbolTable;
using Grc.Sem.Types;
using Grc.Sem.Visitor;

namespace Grc.IR.Visitor
{
	public class IRVisitor : GTypeVisitor
	{
		private Dictionary<Addr, Quad> ir;

		public IRVisitor(out ISymbolTable symbolTable, out Dictionary<NodeBase, GTypeBase> typeForNode)
			: base(out symbolTable, out typeForNode)
		{
			this.ir = new Dictionary<Addr, Quad>();
		}

		public override void Visit(ExprIntegerT n)
		{
			Pre(n);

			n.Addr = new Addr(n.Integer);

			Post(n);
		}

		public override void Visit(ExprCharacterT n)
		{
			Pre(n);

			n.Addr = new Addr(n.Character);

			Post(n);
		}

		public override void Visit(ExprBinOpBase n)
		{
			base.Visit(n);

			n.Addr = new Addr();

			Quad q = Quad.GenQuad(OpBase.GetOp(n), n.Left.Addr, n.Right.Addr, n.Addr);
			ir[q.Addr] = q;
		}

		public override void Visit(ExprPlus n)
		{
			base.Visit(n);

			n.Addr = n.Expr.Addr;
		}

		public override void Visit(ExprMinus n)
		{
			base.Visit(n);

			n.Addr = new Addr();

			Quad q = Quad.GenQuad(OpBase.GetOp(n), new Addr(0), n.Expr.Addr, n.Addr);
			ir[q.Addr] = q;
		}

		public override void Visit(ExprLValIdentifierT n)
		{
			Pre(n);

			n.Addr = new Addr(n.Name);

			Post(n);
		}

		public override void Visit(ExprLValStringT n)
		{
			Pre(n);

			n.Addr = new Addr(n.Text);

			Post(n);
		}

		public override void Visit(ExprFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
			{
				e.Accept(this);

				GTypeBase type = TypeForNode[e];

				Quad q1 = Quad.GenQuad(OpPar.Instance, e.Addr, type.ByRef ? Addr.ByRef : Addr.ByVal, Addr.Empty);
				ir[q1.Addr] = q1;
			}

			n.Addr = new Addr();

			Quad q2 = Quad.GenQuad(OpPar.Instance, Addr.Ret, n.Addr, Addr.Empty);
			ir[q2.Addr] = q2;

			Quad q3 = Quad.GenQuad(OpCall.Instance, Addr.Empty, Addr.Empty, new Addr(n.Name));
			ir[q3.Addr] = q3;

			Post(n);
		}

		public override void Visit(CondAnd n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Left.TrueList.BackPatch(Quad.NextQuad.Addr);

			n.Right.Accept(this);

			n.TrueList = n.Right.TrueList;
			n.FalseList = n.Left.FalseList.Merge(n.Right.FalseList);

			Post(n);
		}

		public override void Visit(CondOr n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Left.FalseList.BackPatch(Quad.NextQuad.Addr);

			n.Right.Accept(this);

			n.TrueList = n.Left.TrueList.Merge(n.Right.TrueList);
			n.FalseList = n.Right.FalseList;

			Post(n);
		}

		public override void Visit(CondNot n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.TrueList = n.Cond.FalseList;
			n.FalseList = n.Cond.TrueList;

			Post(n);
		}

		public override void Visit(CondRelOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			n.TrueList = QuadList.Make(Quad.NextQuad);
			Quad q1 = Quad.GenQuad(OpBase.GetOp(n), n.Left.Addr, n.Right.Addr, Addr.Star);
			ir[q1.Addr] = q1;

			n.FalseList = QuadList.Make(Quad.NextQuad);
			Quad q2 = Quad.GenQuad(OpGoto.Instance, Addr.Empty, Addr.Empty, Addr.Star);
			ir[q2.Addr] = q2;

			Post(n);
		}

		public override void Visit(StmtNoOpT n)
		{
			Pre(n);

			n.NextList = QuadList.Empty();

			Post(n);
		}

		public override void Visit(StmtIfThen n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.Cond.TrueList.BackPatch(Quad.NextQuad.Addr);

			n.Stmt.Accept(this);

			n.NextList = n.Cond.FalseList.Merge(n.Stmt.NextList);

			Post(n);
		}

		public override void Visit(StmtIfThenElse n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.Cond.TrueList.BackPatch(Quad.NextQuad.Addr);

			n.StmtThen.Accept(this);

			List<Quad> l = QuadList.Make(Quad.NextQuad);
			Quad q = Quad.GenQuad(OpGoto.Instance, Addr.Empty, Addr.Empty, Addr.Star);
			ir[q.Addr] = q;

			n.Cond.FalseList.BackPatch(Quad.NextQuad.Addr);

			n.StmtElse.Accept(this);

			n.NextList = l.Merge(n.StmtThen.NextList).Merge(n.StmtElse.NextList);

			Post(n);
		}

		public override void Visit(StmtWhileDo n)
		{
			Pre(n);

			Quad q = Quad.NextQuad;

			n.Cond.Accept(this);

			n.Cond.TrueList.BackPatch(Quad.NextQuad.Addr);

			n.Stmt.Accept(this);

			n.Stmt.NextList.BackPatch(q.Addr);

			q = Quad.GenQuad(OpGoto.Instance, Addr.Empty, Addr.Empty, q.Addr);
			ir[q.Addr] = q;

			n.NextList = n.Cond.FalseList;

			Post(n);
		}

		public override void Visit(StmtBlock n)
		{
			Pre(n);

			foreach (StmtBase s in n.Stmts)
			{
				s.Accept(this);

				s.NextList.BackPatch(Quad.NextQuad.Addr);
			}

			n.NextList = n.Stmts.Count > 0 ? n.Stmts[n.Stmts.Count - 1].NextList : QuadList.Empty();

			Post(n);
		}

		public override void Visit(StmtAssign n)
		{
			base.Visit(n);

			Quad q = Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, Addr.Empty, n.Lval.Addr);
			ir[q.Addr] = q;

			n.NextList = QuadList.Empty();
		}

		public override void Visit(StmtFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
			{
				e.Accept(this);

				GTypeBase type = TypeForNode[e];

				Quad q1 = Quad.GenQuad(OpPar.Instance, e.Addr, type.ByRef ? Addr.ByRef : Addr.ByVal, Addr.Empty);
				ir[q1.Addr] = q1;
			}

			if (!((GTypeFunction)TypeForNode[n]).To.Equals(GTypeNothing.Instance))
			{
				Quad q2 = Quad.GenQuad(OpPar.Instance, Addr.Ret, n.FunCall.Addr, Addr.Empty);
				ir[q2.Addr] = q2;
			}

			Quad q3 = Quad.GenQuad(OpCall.Instance, Addr.Empty, Addr.Empty, new Addr(n.FunCall.Name));
			ir[q3.Addr] = q3;

			n.NextList = QuadList.Empty();

			Post(n);
		}

		public override void Visit(StmtReturn n)
		{
			Pre(n);

			if (n.Expr != null)
				n.Expr.Accept(this);

			Quad q = Quad.GenQuad(OpRet.Instance, Addr.Empty, Addr.Empty, Addr.Empty);
			ir[q.Addr] = q;

			n.NextList = QuadList.Empty();

			Post(n);
		}
	}
}
