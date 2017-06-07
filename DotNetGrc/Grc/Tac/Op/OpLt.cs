using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Op
{
	class OpLt : OpBase
	{
		private static OpLt instance;

		public static OpLt Instance { get { return instance ?? (instance = new OpLt()); } }

		private OpLt()
		{
		}

		public override string ToString()
		{
			return "<";
		}
	}
}
