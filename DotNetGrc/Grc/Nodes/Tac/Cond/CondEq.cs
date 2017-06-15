using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Op;

namespace Grc.Nodes.Cond
{
	public partial class CondEq : CondRelOpBase
	{
		public override OpBase GetOp()
		{
			return new OpEq();
		}
	}
}
