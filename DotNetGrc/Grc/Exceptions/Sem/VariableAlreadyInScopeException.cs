using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Exceptions.Symbols;

namespace Grc.Exceptions.Sem
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
