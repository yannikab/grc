using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public abstract class ExprLValBase : ExprBase
	{
		public ExprLValBase(string text)
			: base(text)
		{
		}
	}
}
