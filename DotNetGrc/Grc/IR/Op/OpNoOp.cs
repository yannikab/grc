using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpNoOp : OpBase
	{
		private static OpNoOp instance;

		public static OpNoOp Instance
		{
			get
			{
				if (instance == null)
					instance = new OpNoOp();

				return instance;
			}
		}

		private OpNoOp()
		{
		}

		public override string ToString()
		{
			return "nop";
		}
	}
}
