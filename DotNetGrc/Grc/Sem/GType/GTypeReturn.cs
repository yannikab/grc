using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public abstract class GTypeReturn : GTypeBase
	{
		public GTypeReturn(bool byRef)
			: base(byRef)
		{
		}
	}
}
