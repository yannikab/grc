using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class MainFunctionWithReturnValueException : GTypeException
	{
		public MainFunctionWithReturnValueException(LocalFuncDecl n)
			: base(string.Format("{0} No return value allowed for main function: {1}", n.Location, n.Text))
		{
		}
	}
}
