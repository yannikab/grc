using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public partial class AddrString : AddrLit
	{
		public int Index { get; set; }

		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, Index);
		}
	}
}
