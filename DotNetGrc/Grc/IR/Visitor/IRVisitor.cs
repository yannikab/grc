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
using Grc.Semantic.SymbolTable;
using Grc.Semantic.Types;
using Grc.Semantic.Visitor;

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
			n.Addr = new Addr(n.Integer);
		}

		public override void Visit(ExprCharacterT n)
		{
			n.Addr = new Addr(n.Character);
		}

		public override void Visit(ExprBinOpBase n)
		{
			base.Visit(n);

			n.Addr = new Addr();

			Quad q = Quad.GenQuad(OpBase.GetOp(n), n.Left.Addr, n.Right.Addr, n.Addr);
			ir[q.Addr] = q;
		}

		public override void Visit(ExprLValIdentifierT n)
		{
			n.Addr = new Addr(n.Name);
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
			n.NextList = QuadList.Empty();
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

			n.NextList = n.Stmts[n.Stmts.Count - 1].NextList;

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

			//int i = 1;
			base.Visit(n);
			foreach (ExprBase e in n.Args)
			{
				e.Accept(this);

				//Quad q = Quad.GenQuad(OpPar.Instance, e.Addr, n.Args[i].
			}

			Post(n);
		}
	}
}
