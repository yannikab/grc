using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Op;

namespace Grc.Nodes.Expr
{
	public partial class ExprMul : ExprBinOpBase
	{
		public override OpBase Op { get { return OpMul.Instance; } }
	}
}
