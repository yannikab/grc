using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Stmt;

namespace Grc.Exceptions.Types
{
	public class IndexedTypeInAssignmentException : TypeException
	{
		public IndexedTypeInAssignmentException(StmtAssign n)
			: base(string.Format("{0} Left hand side of assignment statement {{{1}}} is of type {{{2}}} which is indexed and thus can not be assigned to.", n.Location, n.Text, n.Lval.Type))
		{
		}
	}
}
