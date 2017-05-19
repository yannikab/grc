using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Sem.SymbolTable.Exceptions;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class SymbolTableMissingParameterException : GTypeException
	{
		public SymbolTableMissingParameterException(Parameter p, SymbolTableException e)
			: base(string.Format("{0} Parameter not found in symbol table: {1}", p.Location, p.Text), e)
		{
		}
	}
}
