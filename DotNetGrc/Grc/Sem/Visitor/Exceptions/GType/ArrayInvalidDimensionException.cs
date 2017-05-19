using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;

namespace Grc.Sem.Visitor.Exceptions.GType
{
	public class ArrayInvalidDimensionException : GTypeException
	{
		public ArrayInvalidDimensionException(DimIntegerT d, SystemException e)
			: base(string.Format("{0} Invalid array dimension: {1}", d.Location, d.Integer), e)
		{
		}

		public ArrayInvalidDimensionException(DimIntegerT d)
			: base(string.Format("{0} Invalid array dimension: {1}", d.Location, d.Integer))
		{
		}
	}
}
