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
	public class ReturnDifferentTypeException : TypeException
	{
		public ReturnDifferentTypeException(StmtReturn n, string funcName, TypeFunction t, ExprBase expr)
			: base(string.Format("{0} Function {{{1}}} with type {{{2}}} can not return expression {{{3}}} of type {{{4}}}.", expr.Location, funcName, t, expr.Text, expr.Type))
		{
		}
	}
}
