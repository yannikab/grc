using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Stmt;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class FunctionNotInSymbolTableException : GTypeException
	{
		public FunctionNotInSymbolTableException(LocalFuncDecl n, SymbolTableException e)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Text))
		{
		}

		public FunctionNotInSymbolTableException(LocalFuncDecl n)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Text))
		{
		}

		public FunctionNotInSymbolTableException(ExprFuncCall n, SymbolTableException e)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Text))
		{
		}

		public FunctionNotInSymbolTableException(StmtFuncCall n, SymbolTableException e)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Text))
		{
		}
	}
}
