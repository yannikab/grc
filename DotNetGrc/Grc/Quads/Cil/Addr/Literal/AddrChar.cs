using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public partial class AddrChar : AddrLit
	{
		protected override OpCode LoadOpCode
		{
			get { return OpCodes.Ldc_I4; }
		}

		public override void EmitLoad(ILGenerator ilg)
		{
			ilg.Emit(LoadOpCode, this.s[1]);
		}
	}
}
