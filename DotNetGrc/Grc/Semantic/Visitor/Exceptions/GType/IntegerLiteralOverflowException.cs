using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class IntegerLiteralOverflowException : GTypeException
	{
		public IntegerLiteralOverflowException(ExprIntegerT n, SystemException e)
			: base(string.Format("{0} Integer literal out of bounds: {1}", n.Location, n.Integer), e)
		{
		}
	}
}
