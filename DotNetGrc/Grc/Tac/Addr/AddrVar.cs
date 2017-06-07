using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Addr
{
	public class AddrVar : AddrSym
	{
		private readonly string name;

		public AddrVar(string name)
		{
			this.name = name;
		}

		public override string Name
		{
			get { return name; }
		}

		public override bool Equals(object obj)
		{
			AddrVar that = obj as AddrVar;

			if (that == null)
				return false;

			return this.name == that.name;
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}
	}
}
