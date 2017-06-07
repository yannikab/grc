using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpMod : OpBase
	{
		private static OpMod instance;

		public static OpMod Instance { get { return instance ?? (instance = new OpMod()); } }

		private OpMod()
		{
		}

		public override string ToString()
		{
			return "mod";
		}
	}
}
