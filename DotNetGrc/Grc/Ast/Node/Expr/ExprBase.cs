using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public abstract class ExprBase : NodeBase
	{
		public ExprBase(string text)
			: base(text)
		{
		}
	}
}
