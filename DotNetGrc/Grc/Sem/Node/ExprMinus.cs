using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprMinus : ExprBase
	{
		public override int? StaticInt
		{
			get
			{
				if (!Expr.StaticInt.HasValue)
					return null;

				return checked(-Expr.StaticInt.Value);
			}
		}
	}
}
