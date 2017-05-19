using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Stmt;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class ReturnValueNotAllowedException : GTypeException
	{
		public ReturnValueNotAllowedException(StmtReturn n, string funcName, GTypeFunction t, ExprBase expr)
			: base(string.Format("{0} Function {{{1}}} with return type {{{2}}} can not return value {{{3}}}.", expr.Location, funcName, t.To, expr.Text))
		{
		}
	}
}
