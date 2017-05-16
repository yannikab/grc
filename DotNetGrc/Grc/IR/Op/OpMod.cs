using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpMod : OpBase
	{
		private static OpMod instance;

		public static OpMod Instance
		{
			get
			{
				if (instance == null)
					instance = new OpMod();

				return instance;
			}
		}

		private OpMod()
		{
		}

		public override string ToString()
		{
			return "%";
		}
	}
}
