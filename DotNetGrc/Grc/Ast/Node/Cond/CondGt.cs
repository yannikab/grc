using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Ast.Node.Cond
{
	public class CondGt : CondRelOpBase
	{
		public CondGt(ExprBase left, ExprBase right, string operGt)
			: base(left, right, operGt)
		{
		}
	}
}
