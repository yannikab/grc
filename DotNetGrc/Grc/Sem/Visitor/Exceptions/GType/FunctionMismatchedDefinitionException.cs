using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class FunctionMismatchedDefinitionException : GTypeException
	{
		public FunctionMismatchedDefinitionException(LocalFuncDecl n)
			: base(string.Format("{0} Function definition does not match declaration: {1}", n.Location, n.Text))
		{
		}
	}
}
