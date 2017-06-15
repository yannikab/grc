using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public partial class AddrInt : AddrLit
	{
		private readonly int i;

		public AddrInt(int i)
		{
			this.i = i;
		}

		public override string ToString()
		{
			return i.ToString();
		}
	}
}
