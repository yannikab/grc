using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	partial class OpCall : OpBase
	{
		private OpParRet opParRet;

		public OpCall(OpParRet opParRet)
		{
			this.opParRet = opParRet;
		}

		public OpCall()
		{
		}

		public override string ToString()
		{
			return "call";
		}
	}
}
