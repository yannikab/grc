using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;

namespace Grc.Semantic.Visitor.Exceptions
{
	public class FunctionDefinitionMissingException : SemanticException
	{
		public FunctionDefinitionMissingException(NodeBase n, SymbolBase s)
			: base(string.Format("{0} Definition missing for function: {1}", n.Location, s))
		{
		}
	}
}
