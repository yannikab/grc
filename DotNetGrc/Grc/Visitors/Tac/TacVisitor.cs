using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Sem;
using Grc.Exceptions.Types;
using Grc.Nodes.Cond;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Stmt;
using Grc.Symbols;
using Grc.Tac.Addr;
using Grc.Tac.Op;
using Grc.Tac.Quads;
using Grc.Types;

namespace Grc.Visitors.Tac
{
	public class TacVisitor : ScopeTypeVisitor
	{
		private ExprLValBase indexed;

		public override void Pre(LocalFuncDef n)
		{
			base.Pre(n);

			n.AddQuad(Quad.GenQuad(OpUnit.Instance, new AddrFunc(n.Header.Name), AddrEmpty.Instance, AddrEmpty.Instance));
		}

		public override void Post(LocalFuncDef n)
		{
			base.Post(n);

			if (n.Block.Stmts.Count > 0)
				n.Block.Stmts[n.Block.Stmts.Count - 1].NextList.BackPatch(Quad.NextQuad.Addr);

			n.AddQuad(Quad.GenQuad(OpEndu.Instance, new AddrFunc(n.Header.Name), AddrEmpty.Instance, AddrEmpty.Instance));
		}

		public override void Visit(ExprIntegerT n)
		{
			Pre(n);

			n.Addr = new AddrInt(int.Parse(n.Integer));

			Post(n);
		}

		public override void Visit(ExprCharacterT n)
		{
			Pre(n);

			n.Addr = new AddrChar(n.Character);

			Post(n);
		}

		public override void Visit(ExprBinOpBase n)
		{
			base.Visit(n);

			AddrSym result = new AddrTemp();

			SymbolTable.Insert(new SymbolVar(result.Name, false) { Type = n.Type });

			n.AddQuad(Quad.GenQuad(n.Op, n.Left.Addr, n.Right.Addr, result));

			n.Addr = result;
		}

		public override void Visit(ExprPlus n)
		{
			base.Visit(n);

			AddrSym result = new AddrTemp();

			SymbolTable.Insert(new SymbolVar(result.Name, false) { Type = n.Type });

			n.Addr = result;
		}

		public override void Visit(ExprMinus n)
		{
			base.Visit(n);

			AddrSym result = new AddrTemp();

			SymbolTable.Insert(new SymbolVar(result.Name, false) { Type = n.Type });

			n.AddQuad(Quad.GenQuad(n.Op, new AddrInt(0), n.Expr.Addr, result));

			n.Addr = result;
		}

		public override void Visit(ExprLValIdentifierT n)
		{
			Pre(n);

			SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(n.Name);

			if (symbolVar == null)
				throw new VariableNotInOpenScopesException(n);

			n.Addr = symbolVar.IsPar ? (AddrSym)new AddrPar(n.Name) : (AddrSym)new AddrVar(n.Name);

			Post(n);
		}

		public override void Visit(ExprLValStringT n)
		{
			Pre(n);

			n.Addr = new AddrString(n.Text);

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

			TypeFunction declType = symbolFunc.Type as TypeFunction;

			if (declType == null)
				throw new SymbolInvalidTypeException(n.Name, symbolFunc.Type);

			Stack<AddrBase> passingModes = new Stack<AddrBase>();

			TypeBase current = declType.From;

			while (current is TypeProduct)
			{
				passingModes.Push((current as TypeProduct).Right.ByRef ? (AddrBase)AddrRef.Instance : (AddrBase)AddrVal.Instance);
				current = (current as TypeProduct).Left;
			}

			passingModes.Push(current.ByRef ? (AddrBase)AddrRef.Instance : (AddrBase)AddrVal.Instance);

			foreach (ExprBase e in n.Args)
				n.AddQuad(Quad.GenQuad(OpPar.Instance, e.Addr, passingModes.Pop(), AddrEmpty.Instance));

			Post(n);
		}

		public override void Post(ExprFuncCall n)
		{
			base.Post(n);

			if (!(n.Type.Equals(TypeNothing.Instance)))
			{
				AddrSym value = new AddrTemp();

				SymbolTable.Insert(new SymbolVar(value.Name, false) { Type = n.Type });

				n.AddQuad(Quad.GenQuad(OpPar.Instance, AddrRet.Instance, value, AddrEmpty.Instance));

				n.Addr = value;
			}

			n.AddQuad(Quad.GenQuad(OpCall.Instance, AddrEmpty.Instance, AddrEmpty.Instance, new AddrFunc(n.Name)));
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

			n.AddQuad(Quad.GenQuad(n.Op, n.Left.Addr, n.Right.Addr, AddrStar.Instance));

			n.FalseList = QuadList.Make(Quad.NextQuad);

			n.AddQuad((Quad.GenQuad(OpGoto.Instance, AddrEmpty.Instance, AddrEmpty.Instance, AddrStar.Instance)));

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

			n.AddQuad((Quad.GenQuad(OpGoto.Instance, AddrEmpty.Instance, AddrEmpty.Instance, AddrStar.Instance)));

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

			n.AddQuad(Quad.GenQuad(OpGoto.Instance, AddrEmpty.Instance, AddrEmpty.Instance, q.Addr));

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

			n.AddQuad(Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, AddrEmpty.Instance, n.Lval.Addr));

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

				n.AddQuad(Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, AddrEmpty.Instance, AddrRetVal.Instance));
			}

			n.AddQuad(Quad.GenQuad(OpRet.Instance, AddrEmpty.Instance, AddrEmpty.Instance, AddrEmpty.Instance));

			n.NextList = QuadList.Empty();

			Post(n);
		}

		public override void Post(ExprLValIndexed n)
		{
			base.Post(n);

			if (n.Lval is ExprLValIndexed)
			{
				AddrSym temp = new AddrTemp();

				AddrSym index = new AddrTemp();

				SymbolTable.Insert(new SymbolVar(temp.Name, false) { Type = new TypeInt() });

				SymbolTable.Insert(new SymbolVar(index.Name, false) { Type = new TypeInt() });

				n.AddQuad(Quad.GenQuad(OpMul.Instance, n.Lval.Addr, new AddrInt(((TypeIndexed)n.Lval.Type).Dim), temp));

				n.AddQuad(Quad.GenQuad(OpAdd.Instance, temp, n.Expr.Addr, index));

				n.Addr = index;
			}
			else
			{
				this.indexed = n.Lval;

				AddrSym index = new AddrTemp();

				SymbolTable.Insert(new SymbolVar(index.Name, false) { Type = new TypeInt() });

				n.AddQuad((Quad.GenQuad(OpAssign.Instance, n.Expr.Addr, AddrEmpty.Instance, index)));

				n.Addr = index;
			}

			if (!n.ParentIndexed)
			{
				AddrSym temp = new AddrTemp();

				SymbolTable.Insert(new SymbolVar(temp.Name, false) { Type = new TypeInt() });

				if (indexed is ExprLValIdentifierT)
				{
					ExprLValIdentifierT id = (ExprLValIdentifierT)indexed;

					SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(id.Name);

					if (symbolVar == null)
						throw new VariableNotInOpenScopesException(id);

					AddrSym addr = symbolVar.IsPar ? (AddrSym)new AddrPar(id.Name) : (AddrSym)new AddrVar(id.Name);

					n.AddQuad(Quad.GenQuad(OpArray.Instance, addr, n.Addr, temp));
				}
				else if (indexed is ExprLValStringT)
				{
					ExprLValStringT str = (ExprLValStringT)indexed;

					n.AddQuad(Quad.GenQuad(OpArray.Instance, new AddrString(str.Text), n.Addr, temp));
				}

				n.Addr = new AddrArray(temp.Name);

				this.indexed = null;
			}
		}
	}
}
