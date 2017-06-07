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
		public void AddArgs(IEnumerable<string> names)
		{
			foreach (var n in names)
				args.Add(new ExprLValIdentifierT(n, 0, 0));
		}
	}
}
