using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Exceptions.Types
{
	public class InvalidTypeInNumericExpression : TypeException
	{
		public InvalidTypeInNumericExpression(ExprBase n, ExprBase c)
			: base(string.Format("{0} Expression {{{1}}} of type {{{2}}} not allowed in numeric expression {{{3}}}.", c.Location, c.Text, c.Type, n.Text))
		{
		}
	}
}
