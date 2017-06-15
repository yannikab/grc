using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	partial class OpPar : OpBase
	{
		private static OpPar instance;

		public static OpPar Instance { get { return instance ?? (instance = new OpPar()); } }

		private OpPar()
		{
		}

		public override string ToString()
		{
			return "par";
		}
	}
}
