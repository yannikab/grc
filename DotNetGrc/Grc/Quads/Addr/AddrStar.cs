using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrStar : AddrBase
	{
		private static AddrStar instance;

		public static AddrStar Instance { get { return instance ?? (instance = new AddrStar()); } }

		private AddrStar()
		{
		}

		public override string ToString()
		{
			return "*";
		}
	}
}
