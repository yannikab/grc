using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpMul : OpBase
	{
		private static OpMul instance;

		public static OpMul Instance { get { return instance ?? (instance = new OpMul()); } }

		private OpMul()
		{
		}

		public override string ToString()
		{
			return "*";
		}
	}
}
