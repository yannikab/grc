using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public abstract class GTypeData : GTypeReturn
	{
		public GTypeData(bool byRef)
			: base(byRef)
		{
		}
	}
}
