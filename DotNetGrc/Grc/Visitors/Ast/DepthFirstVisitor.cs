using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Nodes.Cond;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Nodes.Type;

namespace Grc.Visitors.Ast
{
	public class DepthFirstVisitor : VisitorAdapter
	{
		public virtual void Pre(Root n)
		{
		}

		public virtual void Post(Root n)
		{
		}

		public override void Visit(Root n)
		{
			Pre(n);

			n.Program.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprIntegerT n)
		{
		}

		public virtual void Post(ExprIntegerT n)
		{
		}

		public override void Visit(ExprIntegerT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprCharacterT n)
		{
		}

		public virtual void Post(ExprCharacterT n)
		{
		}

		public override void Visit(ExprCharacterT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprLValIdentifierT n)
		{
		}

		public virtual void Post(ExprLValIdentifierT n)
		{
		}

		public override void Visit(ExprLValIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprLValStringT n)
		{
		}

		public virtual void Post(ExprLValStringT n)
		{
		}

		public override void Visit(ExprLValStringT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprLValIndexed n)
		{
		}

		public virtual void In(ExprLValIndexed n)
		{
		}

		public virtual void Post(ExprLValIndexed n)
		{
		}

		public override void Visit(ExprLValIndexed n)
		{
			Pre(n);

			n.Lval.Accept(this);

			In(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprBinOpBase n)
		{
		}

		public virtual void In(ExprBinOpBase n)
		{
		}

		public virtual void Post(ExprBinOpBase n)
		{
		}

		public override void Visit(ExprBinOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			In(n);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprPlus n)
		{
		}

		public virtual void Post(ExprPlus n)
		{
		}

		public override void Visit(ExprPlus n)
		{
			Pre(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprMinus n)
		{
		}

		public virtual void Post(ExprMinus n)
		{
		}

		public override void Visit(ExprMinus n)
		{
			Pre(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprFuncCall n)
		{
		}

		public virtual void Post(ExprFuncCall n)
		{
		}

		public override void Visit(ExprFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
				e.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondRelOpBase n)
		{
		}

		public virtual void In(CondRelOpBase n)
		{
		}

		public virtual void Post(CondRelOpBase n)
		{
		}

		public override void Visit(CondRelOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			In(n);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondOr n)
		{
		}

		public virtual void In(CondOr n)
		{
		}

		public virtual void Post(CondOr n)
		{
		}

		public override void Visit(CondOr n)
		{
			Pre(n);

			n.Left.Accept(this);

			In(n);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondAnd n)
		{
		}

		public virtual void In(CondAnd n)
		{
		}

		public virtual void Post(CondAnd n)
		{
		}

		public override void Visit(CondAnd n)
		{
			Pre(n);

			n.Left.Accept(this);

			In(n);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondNot n)
		{
		}

		public virtual void Post(CondNot n)
		{
		}

		public override void Visit(CondNot n)
		{
			Pre(n);

			n.Cond.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtNoOpT n)
		{
		}

		public virtual void Post(StmtNoOpT n)
		{
		}

		public override void Visit(StmtNoOpT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(StmtBlock n)
		{
		}

		public virtual void Post(StmtBlock n)
		{
		}

		public override void Visit(StmtBlock n)
		{
			Pre(n);

			foreach (StmtBase s in n.Stmts)
				s.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtAssign n)
		{
		}

		public virtual void In(StmtAssign n)
		{
		}

		public virtual void Post(StmtAssign n)
		{
		}

		public override void Visit(StmtAssign n)
		{
			Pre(n);

			n.Lval.Accept(this);

			In(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtIfThen n)
		{
		}

		public virtual void In(StmtIfThen n)
		{
		}

		public virtual void Post(StmtIfThen n)
		{
		}

		public override void Visit(StmtIfThen n)
		{
			Pre(n);

			n.Cond.Accept(this);

			In(n);

			n.Stmt.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtIfThenElse n)
		{
		}

		public virtual void InCondThen(StmtIfThenElse n)
		{
		}

		public virtual void InThenElse(StmtIfThenElse n)
		{
		}

		public virtual void Post(StmtIfThenElse n)
		{
		}

		public override void Visit(StmtIfThenElse n)
		{
			Pre(n);

			n.Cond.Accept(this);

			InCondThen(n);

			n.StmtThen.Accept(this);

			InThenElse(n);

			n.StmtElse.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtWhileDo n)
		{
		}

		public virtual void In(StmtWhileDo n)
		{
		}

		public virtual void Post(StmtWhileDo n)
		{
		}

		public override void Visit(StmtWhileDo n)
		{
			Pre(n);

			n.Cond.Accept(this);

			In(n);

			n.Stmt.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtFuncCall n)
		{
		}

		public virtual void Post(StmtFuncCall n)
		{
		}

		public override void Visit(StmtFuncCall n)
		{
			Pre(n);

			n.FunCall.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtReturn n)
		{
		}

		public virtual void Post(StmtReturn n)
		{
		}

		public override void Visit(StmtReturn n)
		{
			Pre(n);

			if (n.Expr != null)
				n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(LocalFuncDef n)
		{
		}

		public virtual void InHeaderLocals(LocalFuncDef n)
		{
		}

		public virtual void InLocalsBlock(LocalFuncDef n)
		{
		}

		public virtual void Post(LocalFuncDef n)
		{
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			n.Header.Accept(this);

			InHeaderLocals(n);

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			InLocalsBlock(n);

			n.Block.Accept(this);

			Post(n);
		}

		public virtual void Pre(LocalFuncDecl n)
		{
		}

		public virtual void In(LocalFuncDecl n)
		{
		}

		public virtual void Post(LocalFuncDecl n)
		{
		}

		public override void Visit(LocalFuncDecl n)
		{
			Pre(n);

			foreach (HPar h in n.HPars)
				h.Accept(this);

			In(n);

			n.HTypeReturn.Accept(this);

			Post(n);
		}

		public virtual void Pre(HPar n)
		{
		}

		public virtual void In(HPar n)
		{
		}

		public virtual void Post(HPar n)
		{
		}

		public override void Visit(HPar n)
		{
			Pre(n);

			foreach (ParIdentifierT id in n.Identifiers)
				id.Accept(this);

			In(n);

			n.HTypePar.Accept(this);

			Post(n);
		}

		public virtual void Pre(ParIdentifierT n)
		{
		}

		public virtual void Post(ParIdentifierT n)
		{
		}

		public override void Visit(ParIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(HTypePar n)
		{
		}

		public virtual void InDimEmpty(HTypePar n)
		{
		}

		public virtual void InDims(HTypePar n)
		{
		}

		public virtual void Post(HTypePar n)
		{
		}

		public override void Visit(HTypePar n)
		{
			Pre(n);

			n.DataType.Accept(this);

			InDimEmpty(n);

			if (n.DimEmpty != null)
				n.DimEmpty.Accept(this);

			InDims(n);

			foreach (DimIntegerT d in n.Dims)
				d.Accept(this);

			Post(n);
		}

		public virtual void Pre(TypeDataBase n)
		{
		}

		public virtual void Post(TypeDataBase n)
		{
		}

		public override void Visit(TypeDataBase n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(DimEmptyT n)
		{
		}

		public virtual void Post(DimEmptyT n)
		{
		}

		public override void Visit(DimEmptyT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(DimIntegerT n)
		{
		}

		public virtual void Post(DimIntegerT n)
		{
		}

		public override void Visit(DimIntegerT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(LocalVarDef n)
		{
		}

		public virtual void In(LocalVarDef n)
		{
		}

		public virtual void Post(LocalVarDef n)
		{
		}

		public override void Visit(LocalVarDef n)
		{
			Pre(n);

			foreach (VarIdentifierT id in n.Identifiers)
				id.Accept(this);

			In(n);

			n.HTypeVar.Accept(this);

			Post(n);
		}

		public virtual void Pre(HTypeReturn n)
		{
		}

		public virtual void Post(HTypeReturn n)
		{
		}

		public override void Visit(HTypeReturn n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(TypeReturnNothingT n)
		{
		}

		public virtual void Post(TypeReturnNothingT n)
		{
		}

		public override void Visit(TypeReturnNothingT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(VarIdentifierT n)
		{
		}

		public virtual void Post(VarIdentifierT n)
		{
		}

		public override void Visit(VarIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(HTypeVar n)
		{
		}

		public virtual void In(HTypeVar n)
		{
		}

		public virtual void Post(HTypeVar n)
		{
		}

		public override void Visit(HTypeVar n)
		{
			Pre(n);

			n.DataType.Accept(this);

			In(n);

			foreach (DimIntegerT d in n.Dims)
				d.Accept(this);

			Post(n);
		}
	}
}
