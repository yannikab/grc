using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Quads.Addr;
using Grc.Types;

namespace Grc.Quads.Op
{
	partial class OpAssign : OpBase
	{
		public override void EmitQuad(ILGenerator cil)
		{
			if (Quad.Res is AddrRetVal)
			{
				LoadRetVal(cil);
				return;
			}

			if ((Quad.Res as AddrSym).Type.ByRef)
				AssignToByRef(cil);
			else
				AssignToByVal(cil);
		}

		private void LoadRetVal(ILGenerator cil)
		{
			AddrExpr source = (AddrExpr)Quad.Arg1;

			source.EmitLoad(cil);
		}

		private void AssignToByRef(ILGenerator cil)
		{
			AddrSym target = (AddrSym)Quad.Res;

			target.EmitLoad(cil);

			AddrSym source = Quad.Arg1 as AddrSym;

			if (source != null)
			{
				if (source.Type.ByRef)
					source.EmitLoadInd(cil, (TypeData)source.Type);
				else
					source.EmitLoad(cil);
			}
			else
			{
				(Quad.Arg1 as AddrExpr).EmitLoad(cil);
			}

			target.EmitStoreInd(cil, (TypeData)target.Type);
		}

		private void AssignToByVal(ILGenerator cil)
		{
			AddrSym source = Quad.Arg1 as AddrSym;

			if (source != null)
			{
				if (source.Type.ByRef)
					source.EmitLoadInd(cil, (TypeData)source.Type);
				else
					source.EmitLoad(cil);
			}
			else
			{
				(Quad.Arg1 as AddrExpr).EmitLoad(cil);
			}

			AddrSym target = (AddrSym)Quad.Res;

			target.EmitStore(cil);
		}
	}
}
