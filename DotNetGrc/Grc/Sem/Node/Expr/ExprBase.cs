using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public abstract partial class ExprBase : NodeBase
	{
		public virtual int? StaticInt { get { return null; } }
	}
}
