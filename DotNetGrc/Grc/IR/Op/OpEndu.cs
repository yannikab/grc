using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpEndu : OpBase
	{
		private static OpEndu instance;

		public static OpEndu Instance
		{
			get
			{
				if (instance == null)
					instance = new OpEndu();

				return instance;
			}
		}

		private OpEndu()
		{
		}

		public override string ToString()
		{
			return "endu";
		}
	}
}
