using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;

namespace Grc.Ast.Node.Expr
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
