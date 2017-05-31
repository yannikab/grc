using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpMul : OpBase
	{
		private static OpMul instance;

		public static OpMul Instance
		{
			get
			{
				if (instance == null)
					instance = new OpMul();

				return instance;
			}
		}

		private OpMul()
		{
		}

		public override string ToString()
		{
			return "*";
		}
	}
}
