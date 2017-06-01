using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Stmt;
using Grc.Sem.SymbolTable.Symbol;
using Grc.Sem.Types;
using Grc.Sem.Visitor;
using Grc.Sem.Visitor.Exceptions.GType;
using Grc.Sem.Visitor.Exceptions.Sem;
using Grc.Tac.Op;
using Grc.Tac.Quads;

namespace Grc.Tac.Visitor
{
	public class TacVisitor : GTypeVisitor
	{
		private string indexedName;

		protected override void InjectLibraryFunctions()
		{
			SymbolTable.Insert(new SymbolFunc("_puti", true) { Type = new GTypeFunction(new GTypeInt(false), GTypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_putc", true) { Type = new GTypeFunction(new GTypeChar(false), GTypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_puts", true) { Type = new GTypeFunction(new GTypeIndexed(0, new GTypeChar(true)), GTypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("_geti", true) { Type = new GTypeFunction(GTypeNothing.Instance, new GTypeInt(false)) });
			SymbolTable.Insert(new SymbolFunc("_getc", true) { Type = new GTypeFunction(GTypeNothing.Instance, new GTypeChar(false)) });
			SymbolTable.Insert(new SymbolFunc("_gets", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeInt(false), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("_abs", true) { Type = new GTypeFunction(new GTypeInt(false), new GTypeInt(false)) });
			SymbolTable.Insert(new SymbolFunc("_ord", true) { Type = new GTypeFunction(new GTypeChar(false), new GTypeInt(false)) });
			SymbolTable.Insert(new SymbolFunc("_chr", true) { Type = new GTypeFunction(new GTypeInt(false), new GTypeChar(false)) });

			SymbolTable.Insert(new SymbolFunc("_strlen", true) { Type = new GTypeFunction(new GTypeIndexed(0, new GTypeChar(true)), new GTypeInt(false)) });
			SymbolTable.Insert(new SymbolFunc("_strcmp", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), new GTypeInt(false)) });
			SymbolTable.Insert(new SymbolFunc("_strcpy", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("_strcat", true) { Type = new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance) });
		}

		public override void Pre(LocalFuncDef n)
		{
			base.Pre(n);

			n.AddQuad(Quad.GenQuad(OpUnit.Instance, new Addr(n.Header.Name), Addr.Empty, Addr.Empty));
		}

		public override void Post(LocalFuncDef n)
		{
			base.Post(n);

			if (n.Block.Stmts.Count > 0)
				n.Block.Stmts[n.Block.Stmts.Count - 1].NextList.BackPatch(Quad.NextQuad.Addr);

			n.AddQuad(Quad.GenQuad(OpEndu.Instance, new Addr(n.Header.Name), Addr.Empty, Addr.Empty));
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

			n.AddQuad(Quad.GenQuad(OpBase.GetOp(n), n.Left.Addr, n.Right.Addr, n.Addr));
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

			n.AddQuad(Quad.GenQuad(OpBase.GetOp(n), new Addr(0), n.Expr.Addr, n.Addr));
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
				e.Accept(this);

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInOpenScopesException(n);

			GTypeFunction declType = symbolFunc.Type as GTypeFunction;

			if (declType == null)
				throw new SymbolInvalidTypeException(n.Name, symbolFunc.Type);

			Stack<bool> passingModes = new Stack<bool>();

			GTypeBase current = declType.From;

			while (current is GTypeProduct)
			{
				passingModes.Push((current as GTypeProduct).Right.ByRef);
				current = (current as GTypeProduct).Left;
			}

			passingModes.Push(current.ByRef);

			foreach (ExprBase e in n.Args)
				n.AddQuad(Quad.GenQuad(OpPar.Instance, e.Addr, passingModes.Pop() ? Addr.ByRef : Addr.ByVal, Addr.Empty));

			Post(n);
		}

		public override void Post(ExprFuncCall n)
		{
			base.Post(n);

			if (!(n.Type.Equals(GTypeNothing.Instance)))
			{
				n.Addr = new Addr();

				n.AddQuad(Quad.GenQuad(OpPar.Instance, Addr.Ret, n.Addr, Addr.Empty));
			}

			n.AddQuad(Quad.GenQuad(OpCall.Instance, Addr.Empty, Addr.Empty, new Addr(n.Name)));
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

			n.AddQuad(Quad.GenQuad(OpBase.GetOp(n), n.Left.Addr, n.Right.Addr, Addr.Star));

			n.FalseList = QuadList.Make(Quad.NextQuad);

			n.AddQuad((Quad.GenQuad(OpGoto.Instance, Addr.Empty, Addr.Empty, Addr.Star)));

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

			n.AddQuad((Quad.GenQuad(OpGoto.Instance, Addr.Empty, Addr.Empty, Addr.Star)));

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

			n.AddQuad(Quad.GenQuad(OpGoto.Instance, Addr.Empty, Addr.Empty, q.Addr));

			n.NextList = n.Cond.FalseList;

			Post(n);
		}

		public override void Visit(StmtBlock n)
		{
			Pre(n);

			List<Quad> l = QuadList.Empty();

			foreach (StmtBase s in n.Stmts)
			{
				l.BackPatch(Quad.NextQuad.Addr);

				s.Accept(this);

				l = s.NextList;
			}

			n.NextList = l;

			Post(n);
		}

		public override void Visit(StmtAssign n)
		{
			base.Visit(n);

			n.AddQuad(Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, Addr.Empty, n.Lval.Addr));

			n.NextList = QuadList.Empty();
		}

		public override void Visit(StmtFuncCall n)
		{
			Pre(n);

			n.FunCall.Accept(this);

			n.NextList = QuadList.Empty();

			Post(n);
		}

		public override void Visit(StmtReturn n)
		{
			Pre(n);

			if (n.Expr != null)
			{
				n.Expr.Accept(this);

				n.AddQuad(Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, Addr.Empty, Addr.RetVal));
			}

			n.AddQuad(Quad.GenQuad(OpRet.Instance, Addr.Empty, Addr.Empty, Addr.Empty));

			n.NextList = QuadList.Empty();

			Post(n);
		}

		public override void Post(ExprLValIndexed n)
		{
			base.Post(n);

			if (n.Lval is ExprLValIndexed)
			{
				Addr t = new Addr();

				n.Addr = new Addr();

				n.AddQuad(Quad.GenQuad(OpMul.Instance, n.Lval.Addr, new Addr((n.Lval.Type as GTypeIndexed).Dim), t));

				n.AddQuad((Quad.GenQuad(OpAdd.Instance, t, n.Expr.Addr, n.Addr)));
			}
			else
			{
				if (n.Lval is ExprLValIdentifierT)
					this.indexedName = (n.Lval as ExprLValIdentifierT).Name;
				else if (n.Lval is ExprLValStringT)
					this.indexedName = (n.Lval as ExprLValStringT).Text;

				n.Addr = new Addr();

				n.AddQuad((Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, Addr.Empty, n.Addr)));
			}

			if (!n.ParentIndexed)
			{
				Addr t = new Addr();

				n.AddQuad(Quad.GenQuad(OpArray.Instance, new Addr(indexedName), n.Addr, t));

				n.Addr = new Addr(string.Format("[{0}]", t));

				this.indexedName = null;
			}
		}
	}
}
