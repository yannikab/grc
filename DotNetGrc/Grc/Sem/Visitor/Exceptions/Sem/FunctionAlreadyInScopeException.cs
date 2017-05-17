using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Sem.SymbolTable.Exceptions;

namespace Grc.Sem.Visitor.Exceptions.Sem
{
	public class FunctionAlreadyInScopeException : SemanticException
	{
		public FunctionAlreadyInScopeException(NodeBase n, SymbolAlreadyInScopeException e)
			: base(string.Format("{0} Function already in scope: {1}", n.Location, e.Symbol.Name), e)
		{
		}

		public FunctionAlreadyInScopeException(NodeBase n, string name)
			: base(string.Format("{0} Function already in scope: {1}", n.Location, name))
		{
		}
	}
}
