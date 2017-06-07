using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Stmt
{
	public partial class StmtIfThen : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return cond.Tac.Concat(stmt.Tac).Concat(this.tac); }
		}
	}
}
