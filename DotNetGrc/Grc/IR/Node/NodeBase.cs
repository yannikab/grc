using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.IR.Quads;

namespace Grc.Ast.Node
{
	public abstract partial class NodeBase
	{
		protected List<Quad> ir = new List<Quad>();

		public virtual IEnumerable<Quad> IR { get { return ir; } }

		public void AddQuad(Quad q)
		{
			ir.Add(q);
		}
	}
}
