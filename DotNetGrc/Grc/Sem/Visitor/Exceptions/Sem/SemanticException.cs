using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.SymbolTable.Exceptions;

namespace Grc.Sem.Visitor.Exceptions.Sem
{
	public class SemanticException : ApplicationException
	{
		public SemanticException(string message, Exception e)
			: base(message, e)
		{
		}

		public SemanticException(Exception e)
			: base(e.Message, e)
		{
		}

		public SemanticException(string message)
			: base(message)
		{
		}
	}
}
