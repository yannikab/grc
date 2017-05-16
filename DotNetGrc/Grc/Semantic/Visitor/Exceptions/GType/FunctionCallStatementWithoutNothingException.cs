﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Stmt;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class FunctionCallStatementWithoutNothingException : GTypeException
	{
		public FunctionCallStatementWithoutNothingException(StmtFuncCall n)
			: base(string.Format("{0} Function call statement should return nothing: {1}", n.Location, n.Text))
		{
		}
	}
}