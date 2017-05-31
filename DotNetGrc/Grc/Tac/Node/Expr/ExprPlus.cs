using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprPlus : ExprBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return this.tac; }
		}
	}
}
