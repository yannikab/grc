using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrRef : AddrBase
	{
		private static AddrRef instance;

		public static AddrRef Instance { get { return instance ?? (instance = new AddrRef()); } }

		private AddrRef()
		{
		}

		public override string ToString()
		{
			return "R";
		}
	}
}
