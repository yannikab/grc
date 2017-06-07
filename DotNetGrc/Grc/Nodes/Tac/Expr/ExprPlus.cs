using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Quads;
using Grc.Tac.Op;

namespace Grc.Nodes.Expr
{
	public partial class ExprPlus : ExprBase
	{
		public override IEnumerable<Quad> Tac
		{
			get { return this.tac; }
		}

		public OpBase Op { get { return OpAdd.Instance; } }
	}
}
