using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes.Stmt
{
	public partial class StmtBlock : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get
			{
				IEnumerable<Quad> ie = null;

				foreach (StmtBase s in stmts)
					ie = ie == null ? s.Tac : ie.Concat(s.Tac);

				return ie == null ? this.tac : ie.Concat(this.tac);
			}
		}
	}
}
