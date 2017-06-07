using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;

namespace Grc.Nodes.Expr
{
	public abstract partial class ExprBase : NodeBase
	{
		public AddrBase Addr { get; set; }
	}
}
