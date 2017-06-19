using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpParArg : OpBase
	{
		public override void EmitQuad(ILGenerator cil)
		{
			if (Quad.Arg2 is AddrRef)
				LoadByRef(cil);
			else if (Quad.Arg2 is AddrVal)
				LoadByVal(cil);
		}

		private void LoadByRef(ILGenerator cil)
		{
			AddrExpr addrExpr = Quad.Arg1 as AddrExpr;

			if (addrExpr == null)
				return;

			if (addrExpr.Type.ByRef)
				addrExpr.EmitLoad(cil);
			else
				addrExpr.EmitLoadAddr(cil);
		}

		private void LoadByVal(ILGenerator cil)
		{
			AddrExpr addrExpr = Quad.Arg1 as AddrExpr;

			if (addrExpr == null)
			{
				(Quad.Arg1 as AddrExpr).EmitLoad(cil);
				return;
			}

			if (addrExpr.Type.ByRef)
				addrExpr.EmitLoadInd(cil);
			else
				addrExpr.EmitLoad(cil);
		}
	}
}
