using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;

namespace Grc.Sem.SymbolTable.Symbol
{
	public class SymbolFunc : SymbolBase
	{
		private bool defined;

		public bool Defined
		{
			get { return defined; }
			set { defined = value; }
		}

		public SymbolFunc(string name, bool defined, GTypeBase type)
			: base(name, type)
		{
			this.defined = defined;
		}

		public SymbolFunc(string name, bool defined)
			: base(name)
		{
			this.defined = defined;
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
			return base.GetHashCode();
		}
	}
}
