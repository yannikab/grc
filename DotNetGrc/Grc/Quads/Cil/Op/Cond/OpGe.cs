using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	partial class OpGe : OpRel
	{
		public override OpCode OpCode
		{
			get { return OpCodes.Bge; }
		}
	}
}
