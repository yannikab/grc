using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Symbol
{
	public class SymbolFunc : SymbolBase
	{
		public SymbolFunc(string name)
			: base(name)
		{
		}

		public override bool Equals(object obj)
		{
			if (obj as SymbolFunc == null)
				return false;

			SymbolFunc that = (SymbolFunc)obj;

			return base.Equals(that);
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = 31 * hash + base.GetHashCode();
			return hash;
		}
	}
}
