using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class LValueNotIndexedTypeException : GTypeException
	{
		public LValueNotIndexedTypeException(ExprLValIndexed n)
			: base(string.Format("{0} Indexed expression {{{1}}} contains l-value {{{2}}} with type {{{3}}} instead of an indexed type.", n.Location, n.Text, n.Lval.Text, n.Lval.Type))
		{
		}
	}
}
