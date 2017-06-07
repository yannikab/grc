using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class FunctionCallArgsMismatchException : TypeException
	{
		public FunctionCallArgsMismatchException(ExprFuncCall n, TypeBase callType, TypeBase declType)
			: base(string.Format("{0} Function call arguments do not match declaration in number and/or type: {1} [ {2} -> {3} ]", n.Location, n.Text, callType, declType))
		{
		}
	}
}
