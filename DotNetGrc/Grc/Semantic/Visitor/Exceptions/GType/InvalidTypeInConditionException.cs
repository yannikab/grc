using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Semantic.Types;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class InvalidTypeInConditionException : GTypeException
	{
		public InvalidTypeInConditionException(CondBase n, GTypeBase t)
			: base(string.Format("{0} Condition can not involve type {1}: {2}", n.Location, t, n.Text))
		{
		}
	}
}
