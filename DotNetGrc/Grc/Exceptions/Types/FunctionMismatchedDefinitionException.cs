using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;

namespace Grc.Exceptions.Types
{
	public class FunctionMismatchedDefinitionException : TypeException
	{
		public FunctionMismatchedDefinitionException(LocalFuncDecl n)
			: base(string.Format("{0} Function definition does not match declaration: {1}", n.Location, n.Text))
		{
		}
	}
}
