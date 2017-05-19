using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Stmt;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class ReturnWithoutExpressionException : GTypeException
	{
		public ReturnWithoutExpressionException(StmtReturn n, string funcName, GTypeFunction t)
			: base(string.Format("{0} Return statement for function {{{1}}} with type {{{2}}} should provide an expression of type {{{3}}}.", n.Location, funcName, t, t.To))
		{
		}
	}
}
