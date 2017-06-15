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
		public IReadOnlyList<Quad> OwnTac { get { return tac; } }
	}
}
