using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Symbols;

namespace Grc.Exceptions.Symbols
{
	public class SymbolAlreadyInScopeException : SymbolException
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
