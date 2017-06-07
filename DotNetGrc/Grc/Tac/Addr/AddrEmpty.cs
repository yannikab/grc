using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Addr
{
	public class AddrEmpty : AddrBase
	{
		private static AddrEmpty instance;

		public static AddrEmpty Instance { get { return instance ?? (instance = new AddrEmpty()); } }

		private AddrEmpty()
		{
		}

		public override string ToString()
		{
			return "_";
		}
	}
}
