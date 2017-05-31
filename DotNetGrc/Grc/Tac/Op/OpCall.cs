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

		public static OpCall Instance
		{
			get
			{
				if (instance == null)
					instance = new OpCall();

				return instance;
			}
		}

		private OpCall()
		{
		}

		public override string ToString()
		{
			return "call";
		}
	}
}
