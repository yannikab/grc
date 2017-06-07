using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Sem;

namespace Grc.Exceptions.Types
{
	public class TypeException : SemanticException
	{
		public TypeException(string message, Exception e)
			: base(message, e)
		{
		}

		public TypeException(string message)
			: base(message)
		{
		}
	}
}
