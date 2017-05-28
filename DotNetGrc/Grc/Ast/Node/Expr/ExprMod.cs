using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprMod : ExprBinOpBase
	{
		public ExprMod(ExprBase left, ExprBase right, string operMod)
			: base(left, right, operMod)
		{
		}
	}
}
