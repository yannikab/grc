using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public partial class AddrArray : AddrSym
	{
		protected override OpCode LoadOpCode { get { return OpCodes.Ldind_I4; } }

		protected override OpCode StoreOpCode { get { return OpCodes.Stind_I4; } }
	}
}
