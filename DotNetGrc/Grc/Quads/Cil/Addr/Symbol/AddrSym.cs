using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public abstract partial class AddrSym : AddrExpr
	{
		public int Index { get; set; }

		protected abstract OpCode StoreOpCode { get; }

		public override void EmitLoad(ILGenerator ilg)
		{
			ilg.Emit(LoadOpCode, Index);
		}

		public virtual void EmitStore(ILGenerator ilg)
		{
			ilg.Emit(StoreOpCode, Index);
		}
	}
}
