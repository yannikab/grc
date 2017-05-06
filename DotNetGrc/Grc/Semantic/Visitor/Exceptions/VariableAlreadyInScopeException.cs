using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions
{
	public class VariableAlreadyInScopeException : SemanticException
	{
		public VariableAlreadyInScopeException(NodeBase n, SymbolAlreadyInScopeException e)
			: base(string.Format("{0} Variable already in scope:", n.Location, e.Symbol), e)
		{
		}
	}
}
