using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;

namespace Grc.Ast.Node
{
	public abstract partial class NodeBase
	{
		public GTypeBase Type { get; set; }
	}
}
