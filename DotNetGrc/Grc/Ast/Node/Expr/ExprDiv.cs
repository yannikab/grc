using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	class ExprDiv : ExprBinOpBase
	{
		public ExprDiv(ExprBase left, ExprBase right, string operDiv)
			: base(left, right, operDiv)
		{
		}
	}
}
