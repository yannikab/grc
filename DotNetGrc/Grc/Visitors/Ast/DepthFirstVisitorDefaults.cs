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
	public class DepthFirstVisitorDefaults : DepthFirstVisitor
	{
		public virtual void DefaultPre(NodeBase n)
		{
		}

		public virtual void DefaultIn(NodeBase n)
		{
		}

		public virtual void DefaultPost(NodeBase n)
		{
		}

		public override void Pre(Root n)
		{
			DefaultPre(n);
		}

		public override void Post(Root n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprIntegerT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprIntegerT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprCharacterT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprCharacterT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprLValIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprLValStringT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprLValStringT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprLValIndexed n)
		{
			DefaultPre(n);
		}

		public override void In(ExprLValIndexed n)
		{
			DefaultIn(n);
		}

		public override void Post(ExprLValIndexed n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprBinOpBase n)
		{
			DefaultPre(n);
		}

		public override void In(ExprBinOpBase n)
		{
			DefaultIn(n);
		}

		public override void Post(ExprBinOpBase n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprPlus n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprPlus n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprMinus n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprMinus n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprFuncCall n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprFuncCall n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondRelOpBase n)
		{
			DefaultPre(n);
		}

		public override void In(CondRelOpBase n)
		{
			DefaultIn(n);
		}

		public override void Post(CondRelOpBase n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondOr n)
		{
			DefaultPre(n);
		}

		public override void In(CondOr n)
		{
			DefaultIn(n);
		}

		public override void Post(CondOr n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondAnd n)
		{
			DefaultPre(n);
		}

		public override void In(CondAnd n)
		{
			DefaultIn(n);
		}

		public override void Post(CondAnd n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondNot n)
		{
			DefaultPre(n);
		}

		public override void Post(CondNot n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtNoOpT n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtNoOpT n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtBlock n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtBlock n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtAssign n)
		{
			DefaultPre(n);
		}

		public override void In(StmtAssign n)
		{
			DefaultIn(n);
		}

		public override void Post(StmtAssign n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtIfThen n)
		{
			DefaultPre(n);
		}

		public override void In(StmtIfThen n)
		{
			DefaultIn(n);
		}

		public override void Post(StmtIfThen n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtIfThenElse n)
		{
			DefaultPre(n);
		}

		public override void InCondThen(StmtIfThenElse n)
		{
			DefaultIn(n);
		}

		public override void InThenElse(StmtIfThenElse n)
		{
			DefaultIn(n);
		}

		public override void Post(StmtIfThenElse n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtWhileDo n)
		{
			DefaultPre(n);
		}

		public override void In(StmtWhileDo n)
		{
			DefaultIn(n);
		}

		public override void Post(StmtWhileDo n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtFuncCall n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtFuncCall n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtReturn n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtReturn n)
		{
			DefaultPost(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			DefaultPre(n);
		}

		public override void InHeaderLocals(LocalFuncDef n)
		{
			DefaultIn(n);
		}

		public override void InLocalsBlock(LocalFuncDef n)
		{
			DefaultIn(n);
		}

		public override void Post(LocalFuncDef n)
		{
			DefaultPost(n);
		}

		public override void Pre(LocalFuncDecl n)
		{
			DefaultPre(n);
		}

		public override void In(LocalFuncDecl n)
		{
			DefaultIn(n);
		}

		public override void Post(LocalFuncDecl n)
		{
			DefaultPost(n);
		}

		public override void Pre(HPar n)
		{
			DefaultPre(n);
		}

		public override void In(HPar n)
		{
			DefaultIn(n);
		}

		public override void Post(HPar n)
		{
			DefaultPost(n);
		}

		public override void Pre(ParIdentifierT n)
		{
			DefaultPre(n);
		}

		public override void Post(ParIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Pre(HTypePar n)
		{
			DefaultPre(n);
		}

		public override void InDimEmpty(HTypePar n)
		{
			DefaultIn(n);
		}

		public override void InDims(HTypePar n)
		{
			DefaultIn(n);
		}

		public override void Post(HTypePar n)
		{
			DefaultPost(n);
		}

		public override void Pre(TypeDataBase n)
		{
			DefaultPre(n);
		}

		public override void Post(TypeDataBase n)
		{
			DefaultPost(n);
		}

		public override void Pre(DimEmptyT n)
		{
			DefaultPre(n);
		}

		public override void Post(DimEmptyT n)
		{
			DefaultPost(n);
		}

		public override void Pre(DimIntegerT n)
		{
			DefaultPre(n);
		}

		public override void Post(DimIntegerT n)
		{
			DefaultPost(n);
		}

		public override void Pre(LocalVarDef n)
		{
			DefaultPre(n);
		}

		public override void In(LocalVarDef n)
		{
			DefaultIn(n);
		}

		public override void Post(LocalVarDef n)
		{
			DefaultPost(n);
		}

		public override void Pre(HTypeReturn n)
		{
			DefaultPre(n);
		}

		public override void Post(HTypeReturn n)
		{
			DefaultPost(n);
		}

		public override void Pre(TypeReturnNothingT n)
		{
			DefaultPre(n);
		}

		public override void Post(TypeReturnNothingT n)
		{
			DefaultPost(n);
		}

		public override void Pre(VarIdentifierT n)
		{
			DefaultPre(n);
		}

		public override void Post(VarIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Pre(HTypeVar n)
		{
			DefaultPre(n);
		}

		public override void In(HTypeVar n)
		{
			DefaultIn(n);
		}

		public override void Post(HTypeVar n)
		{
			DefaultPost(n);
		}
	}
}
