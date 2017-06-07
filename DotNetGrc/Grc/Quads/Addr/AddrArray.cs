using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrArray : AddrBase
	{
		private readonly string s;

		public AddrArray(string s)
		{
			this.s = s;
		}

		public override string ToString()
		{
			return string.Format("[{0}]", s);
		}
	}
}
