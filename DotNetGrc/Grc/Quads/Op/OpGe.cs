using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpGe : OpBase
	{
		private static OpGe instance;

		public static OpGe Instance { get { return instance ?? (instance = new OpGe()); } }

		private OpGe()
		{
		}

		public override string ToString()
		{
			return ">=";
		}
	}
}
