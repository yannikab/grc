using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Exceptions.Symbols
{
	public class NoCurrentScopeException : SymbolException
	{
		public NoCurrentScopeException()
			: base("No current scope.")
		{
		}
	}
}
