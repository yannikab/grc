using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpCall : OpBase
	{
		private static OpCall instance;

		public static OpCall Instance { get { return instance ?? (instance = new OpCall()); } }

		private OpCall()
		{
		}

		public override string ToString()
		{
			return "call";
		}
	}
}
