using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class OverflowInIntegerExpressionException : GTypeException
	{
		public OverflowInIntegerExpressionException(ExprBase n, SystemException e)
			: base(string.Format("{0} Integer expression out of bounds: {1}", n.Location, n.Text), e)
		{
		}
	}
}
