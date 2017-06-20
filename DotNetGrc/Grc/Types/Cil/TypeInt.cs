using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Types
{
	public partial class TypeInt : TypeData
	{
		public override Type DotNetType { get { return typeof(int); } }

		public override int ByteSize { get { return 4; } }

		public override OpCode LdIndirectOp { get { return OpCodes.Ldind_I4; } }

		public override OpCode StIndirectOp { get { return OpCodes.Stind_I4; } }
	}
}
