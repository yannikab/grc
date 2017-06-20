using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrLoc : AddrVar
	{
		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, Index);
		}

		public override void EmitLoadInd(ILGenerator cil, TypeData typeData)
		{
			cil.Emit(OpCodes.Ldloc, Index);
			cil.Emit(typeData.LdIndirectOp);
		}

		public override void EmitLoadAddr(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloca, Index);
		}

		public override void EmitStore(ILGenerator cil)
		{
			cil.Emit(OpCodes.Stloc, Index);
		}
	}
}
