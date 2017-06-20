using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public partial class AddrChar : AddrLit
	{
		public override void EmitLoad(ILGenerator cil)
		{
			int c;

			switch (this.text)
			{
				case "'\\0'":
					c = 0;
					break;

				case "'\\t'":
					c = 9;
					break;

				case "'\\n'":
					c = 10;
					break;

				case "'\\r'":
					c = 13;
					break;

				case "'\\\\'":
					c = (int)'\\';
					break;

				case "'\\\''":
					c = (int)'\'';
					break;

				case "'\\\"'":
					c = (int)'\"';
					break;

				default:

					if (this.text[2] == 'x')
						c = Convert.ToInt32(this.text.Substring(3, 2), 16);
					else
						c = (int)this.text[1];

					break;
			}

			cil.Emit(OpCodes.Ldc_I4, c);
		}
	}
}
