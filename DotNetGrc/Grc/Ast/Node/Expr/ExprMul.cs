using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	class ExprMul : ExprBinOpBase
	{
		public ExprMul(string operMul)
			: base(operMul)
		{
		}
	}
}
