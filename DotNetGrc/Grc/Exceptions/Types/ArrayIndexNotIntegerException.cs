using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class ArrayIndexNotIntegerException : TypeException
	{
		public ArrayIndexNotIntegerException(ExprLValIndexed n)
			: base(string.Format("{0} Indexed expression {{{1}}} has index expression {{{2}}} with type {{{3}}} instead of type {{{4}}}.", n.Expr.Location, n.Text, n.Expr.Text, n.Expr.Type, new TypeInt()))
		{
		}
	}
}
