using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpDiv : OpBase
	{
		private static OpDiv instance;

		public static OpDiv Instance
		{
			get
			{
				if (instance == null)
					instance = new OpDiv();

				return instance;
			}
		}

		private OpDiv()
		{
		}

		public override string ToString()
		{
			return "div";
		}
	}
}
