using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class ReturnMissingInFunctionBodyException : GTypeException
	{
		public ReturnMissingInFunctionBodyException(LocalFuncDef n, string funcName, GTypeFunction t)
			: base(string.Format("{0} Body of function {{{1}}} with type {{{2}}} should have at least one return statement.", n.Location, funcName, t))
		{
		}
	}
}
