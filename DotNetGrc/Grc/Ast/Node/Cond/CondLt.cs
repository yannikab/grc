using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Ast.Node.Cond
{
	public class CondLt : CondRelOpBase
	{
		public CondLt(ExprBase left, ExprBase right, string operLt)
			: base(left, right, operLt)
		{
		}
	}
}
