using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public abstract partial class AddrExpr : AddrBase
	{
		public virtual void EmitLoad(ILGenerator cil)
		{
			throw new NotImplementedException();
		}

		public virtual void EmitLoadInd(ILGenerator cil)
		{
			throw new NotImplementedException();
		}

		public virtual void EmitLoadAddr(ILGenerator cil)
		{
			throw new NotImplementedException();
		}
	}
}
