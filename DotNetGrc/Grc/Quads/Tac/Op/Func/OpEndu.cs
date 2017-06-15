using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	partial class OpEndu : OpBase
	{
		private static OpEndu instance;

		public static OpEndu Instance { get { return instance ?? (instance = new OpEndu()); } }

		private OpEndu()
		{
		}

		public override string ToString()
		{
			return "endu";
		}
	}
}
