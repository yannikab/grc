using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Grc.Ast.Node
{
	public class NodeException : ApplicationException
	{
		public NodeException(string message)
			: base(message)
		{
		}
	}
}
