using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpAdd : OpBase
	{
		private static OpAdd instance;

		public static OpAdd Instance
		{
			get
			{
				if (instance == null)
					instance = new OpAdd();

				return instance;
			}
		}

		private OpAdd()
		{
		}

		public override string ToString()
		{
			return "+";
		}
	}
}
