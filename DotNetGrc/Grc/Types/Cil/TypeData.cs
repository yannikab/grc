using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Types
{
	public abstract partial class TypeData : TypeReturn
	{
		public abstract OpCode LdIndirectOp { get; }

		public abstract OpCode StIndirectOp { get; }
	}
}
