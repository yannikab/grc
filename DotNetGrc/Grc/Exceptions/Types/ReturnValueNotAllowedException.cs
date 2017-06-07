using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Nodes.Stmt;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class ReturnValueNotAllowedException : TypeException
	{
		public ReturnValueNotAllowedException(StmtReturn n, string funcName, TypeFunction t, ExprBase expr)
			: base(string.Format("{0} Function {{{1}}} with return type {{{2}}} can not return value {{{3}}}.", expr.Location, funcName, t.To, expr.Text))
		{
		}
	}
}
