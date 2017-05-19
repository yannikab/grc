using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class FunctionCallRValueByReferenceException : GTypeException
	{
		public FunctionCallRValueByReferenceException(ExprFuncCall n, GTypeBase callType, GTypeBase declType)
			: base(string.Format("{0} Non l-value expression {{{1}}} passed by reference: [ {2} -> {3} ]", n.Location, n.Text, callType, declType))
		{
		}
	}
}
