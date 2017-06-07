using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Exceptions.Symbols
{
	public class NoOuterScopeException : SymbolException
	{
		public NoOuterScopeException(int level)
			: base(string.Format("No {0} level outer scope.", level))
		{
		}
	}
}
