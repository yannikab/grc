using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public abstract class AddrVar : AddrSym
	{
		public AddrVar(string name)
			: base(name)
		{
		}
	}
}
