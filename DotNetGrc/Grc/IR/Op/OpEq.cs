using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpEq : OpBase
	{
		private static OpEq instance;

		public static OpEq Instance
		{
			get
			{
				if (instance == null)
					instance = new OpEq();

				return instance;
			}
		}

		private OpEq()
		{
		}

		public override string ToString()
		{
			return "=";
		}
	}
}
