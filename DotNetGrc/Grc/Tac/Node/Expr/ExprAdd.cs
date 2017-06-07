using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Tac.Op;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprAdd : ExprBinOpBase
	{
		public override OpBase Op { get { return OpAdd.Instance; } }
	}
}
