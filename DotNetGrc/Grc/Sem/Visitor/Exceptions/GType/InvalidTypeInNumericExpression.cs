using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidTypeInNumericExpression : GTypeException
	{
		public InvalidTypeInNumericExpression(ExprBase n, GTypeBase t)
			: base(string.Format("{0} Numeric expression can not involve type {1}: {2}", n.Location, t, n.Text))
		{
		}
	}
}
