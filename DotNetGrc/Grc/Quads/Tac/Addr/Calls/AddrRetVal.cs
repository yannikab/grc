using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrRetVal : AddrBase
	{
		private static AddrRetVal instance;

		public static AddrRetVal Instance { get { return instance ?? (instance = new AddrRetVal()); } }

		private AddrRetVal()
		{
		}

		public override string ToString()
		{
			return "$$";
		}
	}
}
