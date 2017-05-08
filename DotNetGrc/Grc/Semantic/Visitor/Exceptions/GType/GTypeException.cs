using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Semantic.Visitor.Exceptions.Semantic;

namespace Grc.Semantic.Visitor.Exceptions.GType
{
	public class GTypeException : SemanticException
	{
		public GTypeException(string message, ApplicationException e)
			: base(message, e)
		{
		}

		public GTypeException(string message)
			: base(message)
		{
		}
	}
}
