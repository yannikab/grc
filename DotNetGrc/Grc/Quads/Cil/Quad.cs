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

		public void DefineLabel(ILGenerator ilg)
		{
			if (label != null)
				throw new CilException("Label already defined.");

			label = ilg.DefineLabel();
		}

		public void Emit(ILGenerator ilg)
		{
			if (label.HasValue)
				ilg.MarkLabel(label.Value);

			op.EmitQuad(ilg);
		}
	}
}
