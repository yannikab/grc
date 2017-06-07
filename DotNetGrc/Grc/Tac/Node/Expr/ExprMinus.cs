using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;
using Grc.Tac.Op;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprMinus : ExprBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return expr.Tac.Concat(this.tac); }
		}

		public OpBase Op { get { return OpSub.Instance; } }
	}
}
