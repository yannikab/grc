using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Expr
{
	public abstract partial class ExprBase : NodeBase
	{
		public Addr Addr { get; set; }
	}
}
