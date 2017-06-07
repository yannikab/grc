using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Stmt;

namespace Grc.Exceptions.Types
{
	public class InvalidTypeInAssignmentException : TypeException
	{
		public InvalidTypeInAssignmentException(StmtAssign n)
			: base(string.Format("{0} Right hand side of assignment statement {{{1}}} has type {{{2}}} which can not be converted to left hand side type {{{3}}}.", n.Location, n.Text, n.Expr.Type, n.Lval.Type))
		{
		}
	}
}
