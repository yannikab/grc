using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Cond
{
	public partial class CondOr : CondBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return left.Tac.Concat(right.Tac).Concat(this.tac); }
		}
	}
}
