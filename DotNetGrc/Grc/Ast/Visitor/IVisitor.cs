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
	public interface IVisitor
	{
		void Visit(Root n);

		void Visit(ExprIntegerT n);

		void Visit(ExprCharacterT n);

		void Visit(ExprLValIdentifierT n);

		void Visit(ExprLValStringT n);

		void Visit(ExprLValIndexed n);

		void Visit(ExprBinOpBase n);

		void Visit(ExprPlus n);

		void Visit(ExprMinus n);

		void Visit(ExprFuncCall n);

		void Visit(CondRelOpBase n);

		void Visit(CondOr n);

		void Visit(CondAnd n);

		void Visit(CondNot n);

		void Visit(StmtNoOpT n);

		void Visit(StmtBlock n);

		void Visit(StmtAssign n);

		void Visit(StmtIfThen n);

		void Visit(StmtIfThenElse n);

		void Visit(StmtWhileDo n);

		void Visit(StmtFuncCall n);

		void Visit(StmtReturn n);

		void Visit(LocalFuncDef n);

		void Visit(LocalFuncDecl n);

		void Visit(HPar n);

		void Visit(ParIdentifierT n);

		void Visit(HTypePar n);

		void Visit(TypeDataBase n);

		void Visit(DimEmptyT n);

		void Visit(DimIntegerT n);

		void Visit(HTypeReturn n);

		void Visit(TypeReturnNothingT n);

		void Visit(LocalVarDef n);

		void Visit(VarIdentifierT n);

		void Visit(HTypeVar n);
	}
}
