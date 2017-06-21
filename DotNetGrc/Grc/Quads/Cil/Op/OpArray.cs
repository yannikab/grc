using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using Grc.Types;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpArray : OpBase
	{
		public override void EmitQuad(ILGenerator cil)
		{
			AddrExpr arrayAddr = (AddrExpr)Quad.Arg1;

			AddrTmp index = (AddrTmp)Quad.Arg2;

			AddrTmp elemAddr = (AddrTmp)Quad.Res;

			arrayAddr.EmitLoad(cil);

			index.EmitLoad(cil);

			TypeIndexed typeIndexed = (TypeIndexed)arrayAddr.Type;

			if (typeIndexed.ByteSize != 1)
			{
				cil.Emit(OpCodes.Ldc_I4, typeIndexed.ElementType.ByteSize);

				cil.Emit(OpCodes.Mul);
			}

			cil.Emit(OpCodes.Add);

			elemAddr.EmitStore(cil);
		}
	}
}
