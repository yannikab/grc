using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions
{
	public class FunctionAlreadyInScopeException : SemanticException
	{
		public FunctionAlreadyInScopeException(NodeBase n, SymbolAlreadyInScopeException e)
			: base(string.Format("{0} Function already in scope: {1}", n.Location, e.Symbol), e)
		{
		}
	}
}
