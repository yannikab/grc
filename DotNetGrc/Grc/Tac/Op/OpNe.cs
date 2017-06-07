using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpNe : OpBase
	{
		private static OpNe instance;

		public static OpNe Instance { get { return instance ?? (instance = new OpNe()); } }

		private OpNe()
		{
		}

		public override string ToString()
		{
			return "#";
		}
	}
}
