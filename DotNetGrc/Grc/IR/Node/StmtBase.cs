using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node.Stmt
{
	public abstract partial class StmtBase : NodeBase
	{
		public List<Quad> NextList { get; set; }
	}
}
