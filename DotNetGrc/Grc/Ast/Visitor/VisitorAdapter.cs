using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Visitor
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

		public virtual void Visit(HRef n)
		{

		}

		public virtual void Visit(HVal n)
		{

		}

		public virtual void Visit(FParIdentifierT n)
		{

		}

		public virtual void Visit(LocalVarDef n)
		{

		}

		public virtual void Visit(VarIdentifierT n)
		{

		}

		public virtual void Visit(HType n)
		{

		}

		public virtual void Visit(LocalFuncDef n)
		{

		}

		public virtual void Visit(LocalFuncDecl n)
		{

		}

		public virtual void Visit(TypeDataBase n)
		{

		}

		public virtual void Visit(TypeReturnNothingT n)
		{

		}

		public virtual void Visit(DimEmptyT n)
		{

		}

		public virtual void Visit(DimIntegerT n)
		{

		}
	}
}
