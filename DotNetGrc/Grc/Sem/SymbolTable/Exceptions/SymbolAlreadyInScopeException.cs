using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable.Symbol;

namespace Grc.Sem.SymbolTable.Exceptions
{
	public class SymbolAlreadyInScopeException : SymbolTableException
	{
		private SymbolBase symbol;

		public SymbolBase Symbol { get { return symbol; } }

		public SymbolAlreadyInScopeException(int scope, SymbolBase symbol)
			: base(String.Format("Current scope ({0}) already contains symbol: {1}", scope, symbol))
		{
			this.symbol = symbol;
		}
	}
}
