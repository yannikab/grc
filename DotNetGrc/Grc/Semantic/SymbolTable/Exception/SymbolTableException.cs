using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Exception
{
	public class SymbolTableException : ApplicationException
	{
		public SymbolTableException(string message)
			: base(message)
		{
		}
	}
}
