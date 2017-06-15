using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public abstract partial class AddrExpr : AddrBase
	{
		protected abstract OpCode LoadOpCode { get; }

		public abstract void EmitLoad(ILGenerator ilg);
	}
}
