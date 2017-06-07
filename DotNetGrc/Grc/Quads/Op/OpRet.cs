using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Op
{
	class OpRet : OpBase
	{
		private static OpRet instance;

		public static OpRet Instance { get { return instance ?? (instance = new OpRet()); } }

		private OpRet()
		{
		}

		public override string ToString()
		{
			return "ret";
		}
	}
}
