using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpArray : OpBase
	{
		private static OpArray instance;

		public static OpArray Instance
		{
			get
			{
				if (instance == null)
					instance = new OpArray();

				return instance;
			}
		}

		private OpArray()
		{
		}

		public override string ToString()
		{
			return "array";
		}
	}
}
