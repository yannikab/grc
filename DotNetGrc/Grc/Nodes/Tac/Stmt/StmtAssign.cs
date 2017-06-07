using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Stmt
{
	public partial class StmtAssign : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return lval.Tac.Concat(expr.Tac).Concat(this.tac); }
		}
	}
}
