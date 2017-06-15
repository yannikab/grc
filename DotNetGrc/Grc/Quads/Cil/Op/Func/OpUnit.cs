using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpUnit : OpBase
	{
		public override OpCode OpCode
		{
			get { throw new NotImplementedException(); }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
		}
	}
}
