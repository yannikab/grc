using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrRet : AddrBase
	{
		private static AddrRet instance;

		public static AddrRet Instance { get { return instance ?? (instance = new AddrRet()); } }

		private AddrRet()
		{
		}

		public override string ToString()
		{
			return "RET";
		}
	}
}
