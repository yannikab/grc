using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpSub : OpBase
	{
		private static OpSub instance;

		public static OpSub Instance
		{
			get
			{
				if (instance == null)
					instance = new OpSub();

				return instance;
			}
		}

		private OpSub()
		{
		}

		public override string ToString()
		{
			return "-";
		}
	}
}
