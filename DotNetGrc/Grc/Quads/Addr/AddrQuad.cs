using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrQuad : AddrBase
	{
		private readonly int id;

		public AddrQuad(int id)
		{
			this.id = id;
		}

		public override string ToString()
		{
			return id.ToString();
		}
	}
}
