using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Exception
{
	public class SymbolNotDefinedException : SymbolTableException
	{
		public SymbolNotDefinedException()
			: base("Symbol not defined")
		{
		}
	}
}
