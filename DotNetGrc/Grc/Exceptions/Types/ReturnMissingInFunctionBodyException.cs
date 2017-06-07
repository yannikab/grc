using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class ReturnMissingInFunctionBodyException : TypeException
	{
		public ReturnMissingInFunctionBodyException(LocalFuncDef n, string funcName, TypeFunction t)
			: base(string.Format("{0} Body of function {{{1}}} with type {{{2}}} should have at least one return statement.", n.Location, funcName, t))
		{
		}
	}
}
