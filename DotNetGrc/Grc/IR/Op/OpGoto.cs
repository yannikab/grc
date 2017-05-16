using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpGoto : OpBase
	{
		private static OpGoto instance;

		public static OpGoto Instance
		{
			get
			{
				if (instance == null)
					instance = new OpGoto();

				return instance;
			}
		}

		private OpGoto()
		{
		}

		public override string ToString()
		{
			return "goto";
		}
	}
}
