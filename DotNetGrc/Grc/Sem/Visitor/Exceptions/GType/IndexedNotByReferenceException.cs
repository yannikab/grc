using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class IndexedNotByReferenceException : GTypeException
	{
		public IndexedNotByReferenceException(Parameter p)
			: base(string.Format("{0} Indexed parameter must be passed by reference: {1}", p.Location, p.Text))
		{
		}
	}
}
