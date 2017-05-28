using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtIfThenElse : StmtBase
	{
		public override IEnumerable<Quad> IR
		{
			get { return cond.IR.Concat(stmtThen.IR).Concat(this.ir).Concat(stmtElse.IR); }
		}
	}
}
