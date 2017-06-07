using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;

namespace Grc.Exceptions.Types
{
	public class MainFunctionWithParametersException : TypeException
	{
		public MainFunctionWithParametersException(LocalFuncDecl n)
			: base(string.Format("{0} No parameters allowed for main function: {1}", n.Location, n.Text))
		{
		}
	}
}
