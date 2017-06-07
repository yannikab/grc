using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpUnit : OpBase
	{
		private static OpUnit instance;

		public static OpUnit Instance { get { return instance ?? (instance = new OpUnit()); } }

		private OpUnit()
		{
		}

		public override string ToString()
		{
			return "unit";
		}
	}
}
