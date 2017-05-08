using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Stmt;
using Grc.Semantic.Types;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class InvalidTypeAssignmentException : GTypeException
	{
		public InvalidTypeAssignmentException(StmtAssign n, GTypeBase l, GTypeBase e)
			: base(string.Format("{0} Assigned expression must be of {1} type instead of {2} type: {3}", n.Location, l, e, n.Text))
		{
		}
	}
}
