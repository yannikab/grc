using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpCall : OpBase
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Call; }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
			ilg.Emit(OpCode, (Quad.Res as AddrFunc).MethodInfo);
		}
	}
}
