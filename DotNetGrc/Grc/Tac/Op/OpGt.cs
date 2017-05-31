using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpGt : OpBase
	{
		private static OpGt instance;

		public static OpGt Instance
		{
			get
			{
				if (instance == null)
					instance = new OpGt();

				return instance;
			}
		}

		private OpGt()
		{
		}

		public override string ToString()
		{
			return ">";
		}
	}
}
