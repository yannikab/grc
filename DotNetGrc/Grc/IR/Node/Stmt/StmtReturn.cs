using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtReturn : StmtBase
	{
		public override IEnumerable<Quad> IR
		{
			get { return expr == null ? this.ir : expr.IR.Concat(this.ir); }
		}
	}
}
