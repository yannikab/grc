using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Expr
{
	public partial class ExprFuncCall : ExprBase
	{
		public override IEnumerable<Quad> Tac
		{
			get
			{
				IEnumerable<Quad> ie = null;

				foreach (var a in args)
					ie = ie == null ? a.Tac : ie.Concat(a.Tac);

				return ie == null ? this.tac : ie.Concat(this.tac);
			}
		}
	}
}
