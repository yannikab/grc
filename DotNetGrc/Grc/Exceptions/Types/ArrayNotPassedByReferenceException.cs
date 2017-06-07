using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;

namespace Grc.Exceptions.Types
{
	public class ArrayNotPassedByReferenceException : TypeException
	{
		public ArrayNotPassedByReferenceException(Parameter p)
			: base(string.Format("{0} Indexed parameter {{{1}}} must be passed by reference.", p.Location, p.Text))
		{
		}
	}
}
