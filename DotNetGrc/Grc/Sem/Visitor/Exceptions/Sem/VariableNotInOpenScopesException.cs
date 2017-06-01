using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;

namespace Grc.Sem.Visitor.Exceptions.Sem
{
	public class VariableNotInOpenScopesException : SemanticException
	{
		public VariableNotInOpenScopesException(ExprLValIdentifierT n)
			: base(string.Format("{0} Undefined variable: {1}", n.Location, n.Name))
		{
		}
	}
}
