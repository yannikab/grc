using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;

namespace Grc.Nodes.Cond
{
	public abstract partial class CondBase : NodeBase
	{
		public List<Quad> TrueList { get; set; }
		public List<Quad> FalseList { get; set; }
	}
}
