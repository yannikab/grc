using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Ast.Node.Cond
{
	class CondNe : CondRelOpBase
	{
		public CondNe(ExprBase left, ExprBase right, string operNe)
			: base(left, right, operNe)
		{
		}
	}
}
