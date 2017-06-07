using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;

namespace Grc.Nodes.Stmt
{
	public partial class StmtReturn : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return expr == null ? this.tac : expr.Tac.Concat(this.tac); }
		}
	}
}
