using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;

namespace Grc.Nodes.Cond
{
	public partial class CondNot : CondBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return cond.Tac.Concat(this.tac); }
		}
	}
}
