using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using System.Reflection.Emit;
using Grc.Types;

namespace Grc.Quads.Op
{
	abstract partial class OpExprBin : OpBase
	{
		public virtual OpCode OpCode { get { return OpCodes.Nop; } }

		public override void EmitQuad(ILGenerator cil)
		{
			AddrExpr arg1 = (AddrExpr)Quad.Arg1;

			AddrExpr arg2 = (AddrExpr)Quad.Arg2;

			AddrTmp res = (AddrTmp)Quad.Res;

			if (arg1.Type.ByRef)
				arg1.EmitLoadInd(cil, (TypeData)arg1.Type);
			else
				arg1.EmitLoad(cil);

			if (arg2.Type.ByRef)
				arg2.EmitLoadInd(cil, (TypeData)arg2.Type);
			else
				arg2.EmitLoad(cil);

			cil.Emit(OpCode);

			res.EmitStore(cil);
		}
	}
}
