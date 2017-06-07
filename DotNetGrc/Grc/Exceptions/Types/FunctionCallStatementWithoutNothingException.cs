using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Stmt;

namespace Grc.Exceptions.Types
{
	public class FunctionCallStatementWithoutNothingException : TypeException
	{
		public FunctionCallStatementWithoutNothingException(StmtFuncCall n)
			: base(string.Format("{0} Statement function call must return nothing: {1}", n.Location, n.Text))
		{
		}
	}
}
