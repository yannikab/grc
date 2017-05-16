using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpLt : OpBase
	{
		private static OpLt instance;

		public static OpLt Instance
		{
			get
			{
				if (instance == null)
					instance = new OpLt();

				return instance;
			}
		}

		private OpLt()
		{
		}

		public override string ToString()
		{
			return "<";
		}
	}
}
