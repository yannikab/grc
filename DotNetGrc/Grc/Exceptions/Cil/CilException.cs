using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Exceptions.Cil
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
