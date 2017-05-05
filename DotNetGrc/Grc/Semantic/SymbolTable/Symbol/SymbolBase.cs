using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Symbol
{
	public abstract class SymbolBase : ICloneable
	{
		readonly string name;
		SymbolBase next;
		private int scope;

		public string Name
		{
			get { return name; }
		}

		public SymbolBase Next
		{
			get { return next; }
			set { next = value; }
		}

		public int Scope
		{
			get { return scope; }
			set { scope = value; }
		}

		public SymbolBase(string name)
		{
			this.name = name;
		}

		public override bool Equals(object obj)
		{
			if (obj as SymbolBase == null)
				return false;

			SymbolBase that = (SymbolBase)obj;

			return this.name == that.name;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = 31 * hash + this.name.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return string.Format("[ Name = {0} ]", this.name);
		}

		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}
}
