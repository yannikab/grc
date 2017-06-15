using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrQuad : AddrBase
	{
		private readonly Quad quad;

		public Quad Quad { get { return quad; } }

		public AddrQuad(Quad quad)
		{
			this.quad = quad;
		}

		public override string ToString()
		{
			return quad.Id.ToString();
		}
	}
}
