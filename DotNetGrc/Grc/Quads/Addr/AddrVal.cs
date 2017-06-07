using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrVal : AddrBase
	{
		private static AddrVal instance;

		public static AddrVal Instance { get { return instance ?? (instance = new AddrVal()); } }

		private AddrVal()
		{
		}

		public override string ToString()
		{
			return "V";
		}
	}
}
