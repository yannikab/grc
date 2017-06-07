using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Nodes.Cond
{
	public partial class CondLt : CondRelOpBase
	{
		public CondLt(ExprBase left, ExprBase right, string operLt)
			: base(left, right, operLt)
		{
		}
	}
}
