using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Exceptions.Sem
{
	public class VariableNotInOpenScopesException : SemanticException
	{
		public VariableNotInOpenScopesException(ExprLValIdentifierT n)
			: base(string.Format("{0} Undefined variable: {1}", n.Location, n.Name))
		{
		}
	}
}
