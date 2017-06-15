using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public partial class AddrLoc : AddrVar
	{
		protected override OpCode LoadOpCode { get { return OpCodes.Ldloc_S; } }

		protected override OpCode StoreOpCode { get { return OpCodes.Stloc_S; } }
	}
}
