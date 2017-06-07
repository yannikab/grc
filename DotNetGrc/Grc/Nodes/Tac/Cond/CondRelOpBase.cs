using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;
using Grc.Quads.Op;

namespace Grc.Nodes.Cond
{
	public abstract partial class CondRelOpBase : CondBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return left.Tac.Concat(right.Tac).Concat(this.tac); }
		}

		public abstract OpBase Op { get; }
	}
}
