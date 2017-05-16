﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class VariableNotInSymbolTableException : GTypeException
	{
		public VariableNotInSymbolTableException(Variable v, SymbolTableException e)
			: base(string.Format("{0} Function not found in symbol table: {1}", v.Location, v.Name), e)
		{
		}
	}
}