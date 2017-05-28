using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprFuncCall : ExprBase
	{
		public override IEnumerable<Quad> IR
		{
			get
			{
				IEnumerable<Quad> ie = null;

				foreach (var a in args)
					ie = ie == null ? a.IR : ie.Concat(a.IR);

				return ie == null ? this.ir : ie.Concat(this.ir);
			}
		}
	}
}
