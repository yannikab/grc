using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpGoto : OpBase
	{
		private static OpGoto instance;

		public static OpGoto Instance { get { return instance ?? (instance = new OpGoto()); } }

		private OpGoto()
		{
		}

		public override string ToString()
		{
			return "goto";
		}
	}
}
