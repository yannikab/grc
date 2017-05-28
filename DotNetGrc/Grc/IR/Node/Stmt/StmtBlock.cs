using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtBlock : StmtBase
	{
		public override IEnumerable<Quad> IR
		{
			get
			{
				IEnumerable<Quad> ie = null;

				foreach (StmtBase s in stmts)
					ie = ie == null ? s.IR : ie.Concat(s.IR);

				return ie == null ? this.ir : ie.Concat(this.ir);
			}
		}
	}
}
