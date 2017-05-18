using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpUnit : OpBase
	{
		private static OpUnit instance;

		public static OpUnit Instance
		{
			get
			{
				if (instance == null)
					instance = new OpUnit();

				return instance;
			}
		}

		private OpUnit()
		{
		}

		public override string ToString()
		{
			return "unit";
		}
	}
}
