using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public partial class AddrInt : AddrLit
	{
		protected override OpCode LoadOpCode
		{
			get { return OpCodes.Ldc_I4; }
		}

		public override void EmitLoad(ILGenerator ilg)
		{
			ilg.Emit(LoadOpCode, this.i);
		}
	}
}
