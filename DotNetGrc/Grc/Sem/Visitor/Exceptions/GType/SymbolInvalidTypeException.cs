using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Types;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class SymbolInvalidTypeException : GTypeException
	{
		public SymbolInvalidTypeException(string name, GTypeBase type)
			: base(string.Format("Lookup in symbol table for name {{{0}}} returned symbol with incorrect type: {1}", name, type))
		{
		}
	}
}
