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
		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, elemAddr.Index);
		}

		public override void EmitLoadInd(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, elemAddr.Index);
			cil.Emit(OpCodes.Ldind_I4, Index);
		}

		public override void EmitStoreInd(ILGenerator cil)
		{
			cil.Emit(OpCodes.Stind_I4, Index);
		}
	}
}
