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

		public static OpGt Instance { get { return instance ?? (instance = new OpGt()); } }
		
		private OpGt()
		{
		}

		public override string ToString()
		{
			return ">";
		}
	}
}
