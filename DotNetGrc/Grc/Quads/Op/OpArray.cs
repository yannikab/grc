using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpArray : OpBase
	{
		private static OpArray instance;

		public static OpArray Instance { get { return instance ?? (instance = new OpArray()); } }

		private OpArray()
		{
		}

		public override string ToString()
		{
			return "array";
		}
	}
}
