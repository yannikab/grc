using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Nodes.Expr
{
	public partial class ExprMod : ExprBinOpBase
	{
		public override int? StaticInt
		{
			get
			{
				if (!Left.StaticInt.HasValue)
					return null;

				if (!Right.StaticInt.HasValue)
					return null;

				return checked(Left.StaticInt.Value % Right.StaticInt.Value);
			}
		}
	}
}
