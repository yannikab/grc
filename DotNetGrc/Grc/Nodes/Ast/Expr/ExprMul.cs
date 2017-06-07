using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Nodes.Expr
{
	public partial class ExprMul : ExprBinOpBase
	{
		public ExprMul(ExprBase left, ExprBase right, string operMul)
			: base(left, right, operMul)
		{
		}
	}
}
