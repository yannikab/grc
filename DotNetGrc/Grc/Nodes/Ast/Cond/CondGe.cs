using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Nodes.Cond
{
	public partial class CondGe : CondRelOpBase
	{
		public CondGe(ExprBase left, ExprBase right, string operGe)
			: base(left, right, operGe)
		{
		}
	}
}
