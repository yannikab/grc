using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Quads.Addr;

namespace Grc.Quads.Op
{
	abstract partial class OpRel : OpBase
	{
		public virtual OpCode OpCode { get { return OpCodes.Nop; } }

		public override void EmitQuad(ILGenerator cil)
		{
			AddrExpr arg1 = (AddrExpr)Quad.Arg1;

			AddrExpr arg2 = (AddrExpr)Quad.Arg2;

			Quad quad = (Quad.Res as AddrQuad).Quad;

			if (arg1.Type.ByRef)
				arg1.EmitLoadInd(cil);
			else
				arg1.EmitLoad(cil);

			if (arg2.Type.ByRef)
				arg2.EmitLoadInd(cil);
			else
				arg2.EmitLoad(cil);

			cil.Emit(OpCode, quad.Label.Value);
		}
	}
}
