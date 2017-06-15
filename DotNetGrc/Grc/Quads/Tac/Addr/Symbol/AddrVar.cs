using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public abstract class AddrVar : AddrSym
	{
		public AddrVar(string name, TypeBase type)
			: base(name, type)
		{
		}
	}
}
