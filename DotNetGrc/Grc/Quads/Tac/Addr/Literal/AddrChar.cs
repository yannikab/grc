using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public partial class AddrChar : AddrLit
	{
		private readonly string s;

		public AddrChar(string s)
		{
			this.s = s;
		}

		public override string ToString()
		{
			return s;
		}
	}
}
