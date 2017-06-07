using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;

namespace Grc.Exceptions.Types
{
	public class MainFunctionWithReturnValueException : TypeException
	{
		public MainFunctionWithReturnValueException(LocalFuncDecl n)
			: base(string.Format("{0} No return value allowed for main function: {1}", n.Location, n.Text))
		{
		}
	}
}
