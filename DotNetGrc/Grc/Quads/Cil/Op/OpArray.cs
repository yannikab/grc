using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Quads.Addr;
using Grc.Types;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpArray : OpBase
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Ldelema; }
		}

		public override void EmitQuad(ILGenerator ilg)
		{
			AddrVar array = (AddrVar)Quad.Arg1;

			AddrTmp index = (AddrTmp)Quad.Arg2;

			//AddrTmp elemAddr = (AddrTmp)Quad.Res;

			array.EmitLoad(ilg);

			index.EmitLoad(ilg);

			ilg.Emit(OpCode, ((TypeIndexed)array.Type).InnerDotNetType);

			//elemAddr.EmitStore(ilg);
		}
	}
}
