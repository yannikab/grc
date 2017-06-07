using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Op;

namespace Grc.Nodes.Expr
{
	public partial class ExprDiv : ExprBinOpBase
	{
		public override OpBase Op { get { return OpDiv.Instance; } }
	}
}
