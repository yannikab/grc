using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Sem.SymbolTable.Exceptions;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class SymbolTableMissingVariableException : GTypeException
	{
		public SymbolTableMissingVariableException(Variable v, SymbolTableException e)
			: base(string.Format("{0} Variable not found in symbol table: {1}", v.Location, v.Name), e)
		{
		}
	}
}
