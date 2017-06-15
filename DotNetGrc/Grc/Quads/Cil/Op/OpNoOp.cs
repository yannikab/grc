using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpNoOp : OpBase
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Nop; }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
		}
	}
}
