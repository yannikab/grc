using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;

namespace Grc.Exceptions.Types
{
	public class InvalidTypeInConditionException : TypeException
	{
		public InvalidTypeInConditionException(NodeBase n)
			: base(string.Format("{0} Type {{{1}}} not allowed in condition: {2}", n.Location, n.Type, n.Text))
		{
		}
	}
}
