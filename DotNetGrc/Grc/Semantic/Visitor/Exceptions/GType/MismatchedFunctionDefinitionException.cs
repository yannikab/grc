using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class MismatchedFunctionDefinitionException : GTypeException
	{
		public MismatchedFunctionDefinitionException(LocalFuncDecl n)
			: base(string.Format("{0} Function definition does not match declaration: {1}", n.Location, n.Text))
		{
		}
	}
}
