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
		private bool returned;

		public bool Defined
		{
			get { return defined; }
		}

		public bool Returned
		{
			get { return returned; }
			set { returned = value; }
		}

		public string FullName { get; set; }

		public SymbolFunc(string name, bool defined, GTypeBase type)
			: base(name, type)
		{
			this.defined = defined;
			this.returned = false;
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

			return base.Equals(that) && this.defined == that.defined;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + this.defined.GetHashCode();
		}
	}
}
