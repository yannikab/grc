using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Sem.Visitor.Exceptions.Sem;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class GTypeException : SemanticException
	{
		public GTypeException(string message, Exception e)
			: base(message, e)
		{
		}

		public GTypeException(string message)
			: base(message)
		{
		}
	}
}
