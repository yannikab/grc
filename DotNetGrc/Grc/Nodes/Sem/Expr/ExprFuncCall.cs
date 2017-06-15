using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Nodes.Expr
{
	public partial class ExprFuncCall : ExprBase
	{
		public TypeBase TypeFrom { get; set; }

		public void ChangeName(string name)
		{
			this.id = name;
		}
	}
}
