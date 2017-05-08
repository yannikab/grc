using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions.Semantic
{
	public class FunctionNotInOpenScopesException : SemanticException
	{
		public FunctionNotInOpenScopesException(NodeBase n, SymbolNotInOpenScopesException e)
			: base(string.Format("{0} Undefined function: {1}", n.Location, e.Name), e)
		{
		}
	}
}
