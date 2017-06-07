using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Ast.Node.Cond
{
	public partial class CondLe : CondRelOpBase
	{
		public CondLe(ExprBase left, ExprBase right, string operLe)
			: base(left, right, operLe)
		{
		}
	}
}
