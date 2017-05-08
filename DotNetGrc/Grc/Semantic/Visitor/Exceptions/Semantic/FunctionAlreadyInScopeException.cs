using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions.Semantic
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
