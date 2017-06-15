using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Op;

namespace Grc.Nodes.Expr
{
	public partial class ExprMul : ExprBinOpBase
	{
		public override OpBase GetOp()
		{
			return new OpMul();
		}
	}
}
