using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Cil.Exceptions
{
	public class CilException : ApplicationException
	{
		public CilException(string message)
			: base(message)
		{
		}

		public CilException()
			: base()
		{
		}
	}
}
