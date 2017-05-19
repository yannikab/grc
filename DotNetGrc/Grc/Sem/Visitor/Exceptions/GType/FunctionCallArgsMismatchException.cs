using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class FunctionCallArgsMismatchException : GTypeException
	{
		public FunctionCallArgsMismatchException(ExprFuncCall n, GTypeBase callType, GTypeBase declType)
			: base(string.Format("{0} Function call arguments do not match declaration in number and/or type: {1} [ {2} -> {3} ]", n.Location, n.Text, callType, declType))
		{
		}
	}
}
