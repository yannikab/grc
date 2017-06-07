using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpSub : OpBase
	{
		private static OpSub instance;

		public static OpSub Instance { get { return instance ?? (instance = new OpSub()); } }

		private OpSub()
		{
		}

		public override string ToString()
		{
			return "-";
		}
	}
}
