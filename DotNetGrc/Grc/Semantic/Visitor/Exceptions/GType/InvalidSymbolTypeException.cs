using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Semantic.Visitor.Exceptions.Semantic;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class InvalidSymbolTypeException : GTypeException
	{
		public InvalidSymbolTypeException(string name)
			: base(string.Format("Lookup in symbol table returned symbol with incorrect type: ", name))
		{
		}
	}
}
