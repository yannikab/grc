using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Exceptions.Trg
{
	public class TrgException : ApplicationException
	{
		public TrgException(string message)
			: base(message)
		{
		}

		public TrgException()
			: base()
		{
		}
	}
}
