﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Sem.SymbolTable.Exceptions;

namespace Grc.Sem.Visitor.Exceptions.Sem
{
	public class FunctionNotInOpenScopesException : SemanticException
	{
		public FunctionNotInOpenScopesException(NodeBase n, string name)
			: base(string.Format("{0} Undefined function: {1}", n.Location, name))
		{
		}
	}
}