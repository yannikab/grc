using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Semantic.SymbolTable.Exceptions;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class ParameterNotInSymbolTableException : GTypeException
	{
		public ParameterNotInSymbolTableException(Parameter p, SymbolTableException e)
			: base(string.Format("{0} Parameter not found in symbol table: {1}", p.Location, p.Text), e)
		{
		}

		public ParameterNotInSymbolTableException(Parameter p)
			: base(string.Format("{0} Parameter not found in symbol table: {1}", p.Location, p.Text))
		{
		}
	}
}
