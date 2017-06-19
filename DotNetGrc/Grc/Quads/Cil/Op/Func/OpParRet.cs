using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Quads.Addr;

namespace Grc.Quads.Op
{
	partial class OpParRet : OpBase
	{
		public override void EmitQuad(ILGenerator cil)
		{
			(Quad.Arg2 as AddrTmp).EmitStore(cil);
		}
	}
}
