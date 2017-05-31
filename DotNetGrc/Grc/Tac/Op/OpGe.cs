using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpGe : OpBase
	{
		private static OpGe instance;

		public static OpGe Instance
		{
			get
			{
				if (instance == null)
					instance = new OpGe();

				return instance;
			}
		}

		private OpGe()
		{
		}

		public override string ToString()
		{
			return ">=";
		}
	}
}
