using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using System.Reflection.Emit;
using Grc.Exceptions.Cil;

namespace Grc.Quads.Op
{
	partial class OpAssign : OpBase
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Nop; }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
			AddrExpr source = (AddrExpr)Quad.Arg1;

			source.EmitLoad(ilg);

			AddrRetVal retVal = Quad.Res as AddrRetVal;

			if (retVal != null)
				return;

			AddrSym target = Quad.Res as AddrSym;

			if (target == null)
				throw new CilException("Invalid assignment target.");

			target.EmitStore(ilg);
		}
	}
}
