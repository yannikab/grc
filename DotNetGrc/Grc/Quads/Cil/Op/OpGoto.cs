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
		public override void EmitQuad(ILGenerator cil)
		{
			AddrQuad res = (AddrQuad)Quad.Res;

			cil.Emit(OpCodes.Br, res.Quad.Label.Value);
		}
	}
}
