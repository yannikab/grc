using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Stmt;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class FunctionNotInSymbolTableException : GTypeException
	{
		public FunctionNotInSymbolTableException(NodeBase n)
			: base(string.Format("{0} Function not found in symbol table.", n.Location))
		{
		}

		public FunctionNotInSymbolTableException(LocalFuncDecl n)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Name))
		{
		}

		public FunctionNotInSymbolTableException(ExprFuncCall  n)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Name))
		{
		}

		public FunctionNotInSymbolTableException(StmtFuncCall n)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Name))
		{
		}
	}
}
