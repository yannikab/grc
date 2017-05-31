using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Exceptions
{
	public class TacException : ApplicationException
	{
		public TacException(string message)
			: base(message)
		{
		}

		public TacException()
			: base()
		{
		}
	}
}
