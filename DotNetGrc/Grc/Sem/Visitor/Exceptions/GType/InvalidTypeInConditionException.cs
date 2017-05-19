using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class InvalidTypeInConditionException : GTypeException
	{
		public InvalidTypeInConditionException(NodeBase n)
			: base(string.Format("{0} Type {{{1}}} not allowed in condition: {2}", n.Location, n.Type, n.Text))
		{
		}
	}
}
