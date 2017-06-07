using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpDiv : OpBase
	{
		private static OpDiv instance;

		public static OpDiv Instance { get { return instance ?? (instance = new OpDiv()); } }

		private OpDiv()
		{
		}

		public override string ToString()
		{
			return "div";
		}
	}
}
