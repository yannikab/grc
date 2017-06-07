using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Cond;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Nodes.Type;

namespace Grc.Visitors.Ast
{
	public class VisitorAdapter : IVisitor
	{
		public virtual void Visit(Root n)
		{

		}

		public virtual void Visit(ExprIntegerT n)
		{

		}

		public virtual void Visit(ExprCharacterT n)
		{

		}

		public virtual void Visit(ExprLValIdentifierT n)
		{

		}

		public virtual void Visit(ExprLValStringT n)
		{

		}

		public virtual void Visit(ExprLValIndexed n)
		{

		}

		public virtual void Visit(ExprBinOpBase n)
		{

		}

		public virtual void Visit(ExprPlus n)
		{

		}

		public virtual void Visit(ExprMinus n)
		{

		}

		public virtual void Visit(ExprFuncCall n)
		{

		}

		public virtual void Visit(CondRelOpBase n)
		{

		}

		public virtual void Visit(CondOr n)
		{

		}

		public virtual void Visit(CondAnd n)
		{

		}

		public virtual void Visit(CondNot n)
		{

		}

		public virtual void Visit(StmtNoOpT n)
		{

		}

		public virtual void Visit(StmtBlock n)
		{

		}

		public virtual void Visit(StmtAssign n)
		{

		}

		public virtual void Visit(StmtIfThen n)
		{

		}

		public virtual void Visit(StmtIfThenElse n)
		{

		}

		public virtual void Visit(StmtWhileDo n)
		{

		}

		public virtual void Visit(StmtFuncCall n)
		{

		}

		public virtual void Visit(StmtReturn n)
		{

		}

		public virtual void Visit(LocalFuncDef n)
		{

		}

		public virtual void Visit(LocalFuncDecl n)
		{

		}

		public virtual void Visit(HPar n)
		{

		}

		public virtual void Visit(ParIdentifierT n)
		{

		}

		public virtual void Visit(HTypePar n)
		{

		}

		public virtual void Visit(TypeDataBase n)
		{

		}

		public virtual void Visit(DimEmptyT n)
		{

		}

		public virtual void Visit(DimIntegerT n)
		{

		}

		public virtual void Visit(HTypeReturn n)
		{

		}

		public virtual void Visit(TypeReturnNothingT n)
		{

		}

		public virtual void Visit(LocalVarDef n)
		{

		}

		public virtual void Visit(VarIdentifierT n)
		{

		}

		public virtual void Visit(HTypeVar n)
		{

		}
	}
}
