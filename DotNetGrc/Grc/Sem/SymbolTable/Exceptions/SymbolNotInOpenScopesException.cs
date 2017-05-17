using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable.Symbol;

namespace Grc.Sem.SymbolTable.Exceptions
{
	public class SymbolNotInOpenScopesException : SymbolTableException
	{
		private string name;

		public string Name { get { return name; } }

		public SymbolNotInOpenScopesException(string name)
			: base(string.Format("Symbol not in open scopes: {0}", name))
		{
			this.name = name;
		}
	}
}
