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
	public class ReturnDifferentTypeException : GTypeException
	{
		public ReturnDifferentTypeException(StmtReturn n, string funcName, GTypeFunction t, ExprBase expr)
			: base(string.Format("{0} Function {{{1}}} with type {{{2}}} can not return expression {{{3}}} of type {{{4}}}.", expr.Location, funcName, t, expr.Text, expr.Type))
		{
		}
	}
}
