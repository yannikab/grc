using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Op
{
	public abstract partial class OpBase
	{
		public abstract void EmitQuad(ILGenerator cil);
	}
}
