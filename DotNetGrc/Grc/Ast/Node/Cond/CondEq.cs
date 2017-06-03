using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Ast.Node.Cond
{
	public class CondEq : CondRelOpBase
	{
		public CondEq(ExprBase left, ExprBase right, string operEq)
			: base(left, right, operEq)
		{
		}
	}
}
