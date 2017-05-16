using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Exceptions
{
	public class IRException : ApplicationException
	{
		public IRException(string message)
			: base(message)
		{
		}

		public IRException()
			: base()
		{
		}
	}
}
