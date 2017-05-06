using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions
{
	public class VariableNotInScopeException : SemanticException
	{
		public VariableNotInScopeException(NodeBase n, SymbolNotInScopeException e)
			: base(string.Format("{0} Scope does not contain variable:", n.Location, e.Name), e)
		{
		}
	}
}
