using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Exceptions.Symbols
{
	public abstract class SymbolException : ApplicationException
	{
		public SymbolException(string message)
			: base(message)
		{
		}
	}
}
