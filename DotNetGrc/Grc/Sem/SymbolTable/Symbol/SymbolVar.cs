using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;

namespace Grc.Sem.SymbolTable.Symbol
{
	public class SymbolVar : SymbolBase
	{
		public SymbolVar(string name, GTypeBase type)
			: base(name, type)
		{
		}

		public SymbolVar(string name)
			: base(name)
		{
		}

		public override bool Equals(object obj)
		{
			if (obj as SymbolVar == null)
				return false;

			SymbolVar that = (SymbolVar)obj;

			return base.Equals(that);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
	}
}
