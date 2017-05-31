using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpLe : OpBase
	{
		private static OpLe instance;

		public static OpLe Instance
		{
			get
			{
				if (instance == null)
					instance = new OpLe();

				return instance;
			}
		}

		private OpLe()
		{
		}

		public override string ToString()
		{
			return "<=";
		}
	}
}
