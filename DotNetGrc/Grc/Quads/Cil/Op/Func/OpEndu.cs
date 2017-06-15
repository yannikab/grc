using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpEndu : OpBase
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Ret; }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
			ilg.Emit(OpCode);
		}
	}
}
