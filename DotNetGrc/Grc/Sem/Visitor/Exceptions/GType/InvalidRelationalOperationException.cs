using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Sem.Types;


namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidRelationalOperationException : GTypeException
	{
		public InvalidRelationalOperationException(ExprBase n, GTypeBase t)
			: base(string.Format("{0} Relational operator can not accept type {1}: {2}", n.Location, t, n.Text))
		{
		}

		public InvalidRelationalOperationException(CondRelOpBase n)
			: base(string.Format("{0} Incompatible expressions around relational operator: {1}", n.Location, n.Text))
		{
		}
	}
}
