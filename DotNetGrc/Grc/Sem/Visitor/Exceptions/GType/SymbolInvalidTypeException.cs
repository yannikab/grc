using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class SymbolInvalidTypeException : GTypeException
	{
		public SymbolInvalidTypeException(string name)
			: base(string.Format("Lookup in symbol table returned symbol with incorrect type: ", name))
		{
		}
	}
}
