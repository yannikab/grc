using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpNe : OpBase
	{
		private static OpNe instance;

		public static OpNe Instance
		{
			get
			{
				if (instance == null)
					instance = new OpNe();

				return instance;
			}
		}

		private OpNe()
		{
		}

		public override string ToString()
		{
			return "#";
		}
	}
}
