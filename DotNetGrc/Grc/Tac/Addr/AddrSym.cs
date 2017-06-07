using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Addr
{
	public abstract class AddrSym : AddrBase
	{
		public abstract string Name { get; }

		public override string ToString()
		{
			return Name;
		}
	}
}
