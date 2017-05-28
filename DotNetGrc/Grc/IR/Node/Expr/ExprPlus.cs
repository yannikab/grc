using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprPlus : ExprBase
	{
		public override IEnumerable<Quad> IR
		{
			get { return this.ir; }
		}
	}
}
