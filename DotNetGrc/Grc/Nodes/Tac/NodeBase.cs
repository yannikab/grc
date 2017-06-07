using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads;

namespace Grc.Nodes
{
	public abstract partial class NodeBase
	{
		protected List<Quad> tac = new List<Quad>();

		public virtual IEnumerable<Quad> Tac { get { return tac; } }

		public void AddQuad(Quad q)
		{
			tac.Add(q);
		}
	}
}
