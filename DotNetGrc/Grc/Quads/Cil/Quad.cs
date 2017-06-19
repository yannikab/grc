using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using Grc.Exceptions.Cil;

namespace Grc.Quads
{
	public partial class Quad
	{
		private Label? label;

		public Label? Label { get { return label; } }

		public void DefineLabel(ILGenerator cil)
		{
			if (label != null)
				throw new CilException("Label already defined.");

			label = cil.DefineLabel();
		}

		public void Emit(ILGenerator cil)
		{
			if (label.HasValue)
				cil.MarkLabel(label.Value);

			op.EmitQuad(cil);
		}
	}
}
