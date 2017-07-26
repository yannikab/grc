using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public abstract partial class AddrSym : AddrExpr
	{
		public short Index { get; set; }

		public virtual void EmitStore(ILGenerator cil)
		{
			throw new NotImplementedException();
		}

		public virtual void EmitStoreInd(ILGenerator cil, TypeData typeData)
		{
			throw new NotImplementedException();
		}
	}
}
