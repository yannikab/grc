using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Quads.Addr;

namespace Grc.Quads.Op
{
	partial class OpPar : OpBase
	{
		public override OpCode OpCode
		{
			get { throw new NotImplementedException(); }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
			AddrExpr arg = (AddrExpr)Quad.Arg1;

			arg.EmitLoad(ilg);
		}
	}
}
