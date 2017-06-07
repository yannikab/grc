using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpAdd : OpBase
	{
		private static OpAdd instance;

		public static OpAdd Instance { get { return instance ?? (instance = new OpAdd()); } }

		private OpAdd()
		{
		}

		public override string ToString()
		{
			return "+";
		}
	}
}
