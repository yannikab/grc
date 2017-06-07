using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Exceptions.Types
{
	public class OverflowInIntegerExpressionException : TypeException
	{
		public OverflowInIntegerExpressionException(ExprBase n, SystemException e)
			: base(string.Format("{0} Integer expression out of bounds: {1}", n.Location, n.Text), e)
		{
		}
	}
}
