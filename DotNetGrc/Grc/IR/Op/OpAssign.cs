using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpAssign : OpBase
	{
		private static OpAssign instance;

		public static OpAssign Instance
		{
			get
			{
				if (instance == null)
					instance = new OpAssign();

				return instance;
			}
		}

		private OpAssign()
		{
		}

		public override string ToString()
		{
			return "<-";
		}
	}
}
