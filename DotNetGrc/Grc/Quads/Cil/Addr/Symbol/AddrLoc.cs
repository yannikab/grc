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
		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, Index);
		}

		public override void EmitLoadInd(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, Index);
			cil.Emit(OpCodes.Ldind_I4);
		}

		public override void EmitLoadAddr(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloca, Index);
		}

		public override void EmitStore(ILGenerator cil)
		{
			cil.Emit(OpCodes.Stloc, Index);
		}

		public override void EmitStoreInd(ILGenerator cil)
		{
			cil.Emit(OpCodes.Stind_I4);
		}
	}
}
