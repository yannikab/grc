using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrArray : AddrSym
	{
		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, elemAddr.Index);
		}

		public override void EmitLoadInd(ILGenerator cil, TypeData typeData)
		{
			cil.Emit(OpCodes.Ldloc, elemAddr.Index);
			cil.Emit(typeData.LdIndirectOp);
		}

		public override void EmitStoreInd(ILGenerator cil, TypeData typeData)
		{
			cil.Emit(typeData.StIndirectOp);
		}
	}
}
