using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public partial class AddrTmp : AddrSym
	{
		protected override OpCode LoadOpCode { get { return OpCodes.Ldloc; } }

		protected override OpCode StoreOpCode { get { return OpCodes.Stloc; } }
	}
}
