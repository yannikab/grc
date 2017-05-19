using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class FunctionNotInSymbolTableException : GTypeException
	{
		public FunctionNotInSymbolTableException(NodeBase n)
			: base(string.Format("{0} Function not found in symbol table: {1}", n.Location, n.Text))
		{
		}
	}
}
