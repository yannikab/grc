using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrArg : AddrVar
	{
		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldarg, Index);
		}

		public override void EmitLoadInd(ILGenerator cil, TypeData typeData)
		{
			cil.Emit(OpCodes.Ldarg, Index);
			cil.Emit(typeData.LdIndirectOp);
		}

		public override void EmitLoadAddr(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldarga, Index);
		}

		public override void EmitStore(ILGenerator cil)
		{
			cil.Emit(OpCodes.Starg, Index);
		}
	}
}
