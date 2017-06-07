using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Symbols
{
	public partial class SymbolVar : SymbolBase
	{
		public bool IsPar { get; private set; }

		public SymbolVar(string name, bool isPar)
			: base(name)
		{
			this.IsPar = isPar;
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
