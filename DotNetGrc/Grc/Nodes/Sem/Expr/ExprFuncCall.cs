using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Nodes.Expr
{
	public partial class ExprFuncCall : ExprBase
	{
		public void ChangeName(string name)
		{
			this.id = name;
		}
	}
}
