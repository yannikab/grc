using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidTypeInNumericExpression : GTypeException
	{
		public InvalidTypeInNumericExpression(ExprBase n, ExprBase c)
			: base(string.Format("{0} Expression {{{1}}} of type {{{2}}} not allowed in numeric expression {{{3}}}.", c.Location, c.Text, c.Type, n.Text))
		{
		}
	}
}
