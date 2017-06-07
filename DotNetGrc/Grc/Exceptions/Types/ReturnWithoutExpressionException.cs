using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Stmt;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class ReturnWithoutExpressionException : TypeException
	{
		public ReturnWithoutExpressionException(StmtReturn n, string funcName, TypeFunction t)
			: base(string.Format("{0} Return statement for function {{{1}}} with type {{{2}}} should provide an expression of type {{{3}}}.", n.Location, funcName, t, t.To))
		{
		}
	}
}
