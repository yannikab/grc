using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpAssign : OpBase
	{
		private static OpAssign instance;

		public static OpAssign Instance { get { return instance ?? (instance = new OpAssign()); } }

		private OpAssign()
		{
		}

		public override string ToString()
		{
			return "<-";
		}
	}
}
