using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.SymbolTable.Exceptions
{
	public class NoOuterScopeException : SymbolTableException
	{
		public NoOuterScopeException(int level)
			: base(string.Format("No {0} level outer scope.", level))
		{
		}
	}
}
