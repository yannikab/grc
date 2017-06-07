using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpNoOp : OpBase
	{
		private static OpNoOp instance;

		public static OpNoOp Instance { get { return instance ?? (instance = new OpNoOp()); } }

		private OpNoOp()
		{
		}

		public override string ToString()
		{
			return "nop";
		}
	}
}
