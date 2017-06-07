using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Stmt
{
	public partial class StmtIfThenElse : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return cond.Tac.Concat(stmtThen.Tac).Concat(this.tac).Concat(stmtElse.Tac); }
		}
	}
}
