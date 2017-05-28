using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprLValIndexed : ExprLValBase
	{
		public override IEnumerable<Quad> IR
		{
			get { return lval.IR.Concat(expr.IR).Concat(this.ir); }
		}
	}
}
