using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrChar : AddrBase
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
