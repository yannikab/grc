using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Op;

namespace Grc.Nodes.Cond
{
	public partial class CondNe : CondRelOpBase
	{
		public override OpBase Op { get { return OpNe.Instance; } }
	}
}
