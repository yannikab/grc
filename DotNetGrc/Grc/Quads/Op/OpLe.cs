using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpLe : OpBase
	{
		private static OpLe instance;

		public static OpLe Instance { get { return instance ?? (instance = new OpLe()); } }

		private OpLe()
		{
		}

		public override string ToString()
		{
			return "<=";
		}
	}
}
