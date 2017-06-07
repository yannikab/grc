using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Nodes.Cond
{
	public partial class CondEq : CondRelOpBase
	{
		public CondEq(ExprBase left, ExprBase right, string operEq)
			: base(left, right, operEq)
		{
		}
	}
}
