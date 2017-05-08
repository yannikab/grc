using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions.Semantic
{
	public class VariableAlreadyInScopeException : SemanticException
	{
		public VariableAlreadyInScopeException(Parameter n, SymbolAlreadyInScopeException e)
			: base(string.Format("{0} Variable already in scope: {1}", n.Location, n.Text), e)
		{
		}

		public VariableAlreadyInScopeException(Variable n, SymbolAlreadyInScopeException e)
			: base(string.Format("{0} Variable already in scope: {1}", n.Location, n.Text), e)
		{
		}
	}
}
