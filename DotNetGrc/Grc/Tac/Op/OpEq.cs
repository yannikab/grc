using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpEq : OpBase
	{
		private static OpEq instance;

		public static OpEq Instance { get { return instance ?? (instance = new OpEq()); } }

		private OpEq()
		{
		}

		public override string ToString()
		{
			return "=";
		}
	}
}
