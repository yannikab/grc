using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Exceptions.Types
{
	public class SymbolInvalidTypeException : TypeException
	{
		public SymbolInvalidTypeException(string name, TypeBase type)
			: base(string.Format("Lookup in symbol table for name {{{0}}} returned symbol with incorrect type: {1}", name, type))
		{
		}
	}
}
