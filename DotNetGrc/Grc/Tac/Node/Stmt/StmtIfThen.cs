using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtIfThen : StmtBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return cond.Tac.Concat(stmt.Tac).Concat(this.tac); }
		}
	}
}
