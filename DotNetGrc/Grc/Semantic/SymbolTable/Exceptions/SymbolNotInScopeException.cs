using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Semantic.SymbolTable.Symbol;

namespace Grc.Semantic.SymbolTable.Exceptions
{
	public class SymbolNotInScopeException : SymbolTableException
	{
		private string name;

		public string Name { get { return name; } }

		public SymbolNotInScopeException(string name)
			: base(string.Format("Symbol not in scope: {0}", name))
		{
			this.name = name;
		}
	}
}
