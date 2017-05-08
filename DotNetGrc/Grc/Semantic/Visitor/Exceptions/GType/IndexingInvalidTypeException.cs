using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Expr;
using Grc.Semantic.Types;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class IndexingInvalidTypeException : GTypeException
	{
		public IndexingInvalidTypeException(ExprLValIndexed n, GTypeBase t)
			: base(string.Format("{0} Expression must be of {1} type instead of {2} type: {3}", n.Expr.Location, typeof(GTypeIndexed).Name, t, n.Text))
		{
		}
	}
}
