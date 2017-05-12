using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	class ExprSub : ExprBinOpBase
	{
		public ExprSub(ExprBase left, ExprBase right, string operSub)
			: base(left, right, operSub)
		{
		}
	}
}
