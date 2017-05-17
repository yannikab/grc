using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Op
{
	class OpRet : OpBase
	{
		private static OpRet instance;

		public static OpRet Instance
		{
			get
			{
				if (instance == null)
					instance = new OpRet();

				return instance;
			}
		}

		private OpRet()
		{
		}

		public override string ToString()
		{
			return "ret";
		}
	}
}
