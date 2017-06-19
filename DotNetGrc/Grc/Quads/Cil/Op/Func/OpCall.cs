﻿using System;
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
		public override void EmitQuad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Call, (Quad.Res as AddrFunc).MethodInfo);
		}
	}
}
