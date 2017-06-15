using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Quads.Addr;

namespace Grc.Quads.Op
{
	partial class OpGoto : OpBase
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Br; }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
			AddrQuad res = (AddrQuad)Quad.Res;

			ilg.Emit(OpCode, res.Quad.Label.Value);
		}
	}
}
