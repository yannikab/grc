using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public partial class AddrFunc : AddrBase
	{
		private readonly string name;

		public string Name { get { return name; } }

		public AddrFunc(string name)
		{
			this.name = name;
		}

		public override string ToString()
		{
			return name;
		}
	}
}
