using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Exceptions
{
	public class SymbolNotDefinedException : SymbolTableException
	{
		public SymbolNotDefinedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public SymbolNotDefinedException(string message)
			: base(message)
		{
		}

		public SymbolNotDefinedException()
			: base("Symbol not defined")
		{
		}
	}
}
