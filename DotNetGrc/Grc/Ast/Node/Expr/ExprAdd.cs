using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprAdd : ExprBinOpBase
	{
		public ExprAdd(ExprBase left, ExprBase right, string operAdd)
			: base(left, right, operAdd)
		{
		}
	}
}
