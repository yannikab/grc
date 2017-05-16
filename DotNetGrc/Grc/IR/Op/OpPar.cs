using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpPar : OpBase
	{
		private static OpPar instance;

		public static OpPar Instance
		{
			get
			{
				if (instance == null)
					instance = new OpPar();

				return instance;
			}
		}

		private OpPar()
		{
		}

		public override string ToString()
		{
			return "par";
		}
	}
}
