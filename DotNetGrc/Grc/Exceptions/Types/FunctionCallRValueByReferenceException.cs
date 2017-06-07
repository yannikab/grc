using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class FunctionCallRValueByReferenceException : TypeException
	{
		public FunctionCallRValueByReferenceException(ExprFuncCall n, TypeBase callType, TypeBase declType)
			: base(string.Format("{0} Non l-value expression passed by reference in function call {{{1}}}: [ {2} -> {3} ]", n.Location, n.Text, callType, declType))
		{
		}
	}
}
