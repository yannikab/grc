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
		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, Index);
		}

		public override void EmitStore(ILGenerator cil)
		{
			cil.Emit(OpCodes.Stloc, Index);
		}
	}
}
