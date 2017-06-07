using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrPar : AddrSym
	{
		private readonly string name;

		public AddrPar(string name)
		{
			this.name = name;
		}

		public override string Name
		{
			get { return name; }
		}

		public override bool Equals(object obj)
		{
			AddrPar that = obj as AddrPar;

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
