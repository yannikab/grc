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
		public override void EmitQuad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ret);
		}
	}
}
