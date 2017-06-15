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
		protected override OpCode LoadOpCode
		{
			get { return OpCodes.Ldstr; }
		}

		public override void EmitLoad(ILGenerator ilg)
		{
			throw new NotImplementedException();
		}
	}
}
