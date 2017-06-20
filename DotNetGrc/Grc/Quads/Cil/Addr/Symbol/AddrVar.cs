using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public abstract partial class AddrVar : AddrSym
	{
		public override void EmitStoreInd(ILGenerator cil, TypeData typeData)
		{
			cil.Emit(typeData.StIndirectOp);
		}
	}
}
