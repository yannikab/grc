﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Stmt;
using Grc.Nodes;

namespace Grc.Exceptions.Sem
{
	public class FunctionNotInOpenScopesException : SemanticException
	{
		public FunctionNotInOpenScopesException(LocalFuncDecl n)
			: base(string.Format("{0} Undefined function: {1}", n.Location, n.Name))
		{
		}

		public FunctionNotInOpenScopesException(ExprFuncCall n)
			: base(string.Format("{0} Undefined function: {1}", n.Location, n.Name))
		{
		}

		public FunctionNotInOpenScopesException(StmtFuncCall n)
			: base(string.Format("{0} Undefined function: {1}", n.Location, n.Name))
		{
		}

		public FunctionNotInOpenScopesException(NodeBase n)
			: base(string.Format("{0} Undefined function.", n.Location))
		{
		}
	}
}
