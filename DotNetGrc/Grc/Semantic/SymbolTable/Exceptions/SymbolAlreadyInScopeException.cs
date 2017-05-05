using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Exceptions
{
	public class SymbolAlreadyInScopeException : SymbolTableException
	{
		public SymbolAlreadyInScopeException(string message)
			: base(message)
		{
		}
	}
}
