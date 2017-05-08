using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class FunctionArgsMismatchException : GTypeException
	{
		public FunctionArgsMismatchException(ExprFuncCall n)
			: base(string.Format("{0} Function call arguments do not match declaration in number and/or type: {1}", n.Location, n.Text))
		{
		}
	}
}
