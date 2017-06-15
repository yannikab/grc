using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	abstract partial class OpExprBin : OpBase
	{
		public override void EmitQuad(ILGenerator ilg)
		{
			AddrExpr arg1 = (AddrExpr)Quad.Arg1;

			AddrExpr arg2 = (AddrExpr)Quad.Arg2;

			AddrTmp res = (AddrTmp)Quad.Res;

			arg1.EmitLoad(ilg);

			arg2.EmitLoad(ilg);

			ilg.Emit(OpCode);

			res.EmitStore(ilg);
		}
	}
}
