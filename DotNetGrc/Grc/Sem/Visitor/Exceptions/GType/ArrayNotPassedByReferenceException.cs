using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class ArrayNotPassedByReferenceException : GTypeException
	{
		public ArrayNotPassedByReferenceException(Parameter p)
			: base(string.Format("{0} Indexed parameter {{{1}}} must be passed by reference.", p.Location, p.Text))
		{
		}
	}
}
