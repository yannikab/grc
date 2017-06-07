using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Nodes.Cond
{
	public partial class CondGt : CondRelOpBase
	{
		public CondGt(ExprBase left, ExprBase right, string operGt)
			: base(left, right, operGt)
		{
		}
	}
}
