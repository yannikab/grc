using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Stmt;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidTypeInAssignmentException : GTypeException
	{
		public InvalidTypeInAssignmentException(StmtAssign n)
			: base(string.Format("{0} Right hand side of assignment statement {{{1}}} must be of type {{{2}}} instead of type {{{3}}}.", n.Location, n.Text, n.Lval.Type, n.Expr.Type))
		{
		}
	}
}
