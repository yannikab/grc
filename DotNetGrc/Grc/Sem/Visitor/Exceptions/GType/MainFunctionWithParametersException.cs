using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class MainFunctionWithParametersException : GTypeException
	{
		public MainFunctionWithParametersException(LocalFuncDecl n)
			: base(string.Format("{0} No parameters allowed for main function: {1}", n.Location, n.Text))
		{
		}
	}
}
