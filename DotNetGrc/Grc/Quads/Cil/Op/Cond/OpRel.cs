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
		public override void EmitQuad(ILGenerator ilg)
		{
			AddrExpr arg1 = (AddrExpr)Quad.Arg1;

			AddrExpr arg2 = (AddrExpr)Quad.Arg2;

			Quad quad = (Quad.Res as AddrQuad).Quad;

			arg1.EmitLoad(ilg);

			arg2.EmitLoad(ilg);

			ilg.Emit(OpCode, quad.Label.Value);
		}
	}
}
