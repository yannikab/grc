using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Sem.SymbolTable.Symbol;

namespace Grc.Sem.Visitor.Exceptions.Sem
{
	public class FunctionDefinitionMissingException : SemanticException
	{
		public FunctionDefinitionMissingException(LocalFuncDecl n, SymbolBase s)
			: base(string.Format("{0} Definition missing for function: {1}", n.Location, n.Text))
		{
		}
	}
}
