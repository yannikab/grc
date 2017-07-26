using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;

namespace Grc.Quads.Addr
{
	public partial class AddrString : AddrLit
	{
		public short Index { get; set; }

		public override void EmitLoad(ILGenerator cil)
		{
			cil.Emit(OpCodes.Ldloc, Index);
		}

		public byte[] GetByteText()
		{
			List<byte> bytes = new List<byte>();

			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] != '\\')
				{
					bytes.Add((byte)text[i]);
				}
				else
				{
					i++;

					switch (text[i])
					{
						case '0':

							bytes.Add(0);
							break;

						case 't':

							bytes.Add(9);
							break;

						case 'n':

							bytes.Add(10);
							break;

						case 'r':

							bytes.Add(13);
							break;

						case '\\':
						case '\'':
						case '"':

							bytes.Add((byte)text[i]);
							break;

						case 'x':

							bytes.Add(Convert.ToByte(string.Format("{0}{1}", text[++i], text[++i]), 16));
							break;
					}
				}
			}

			bytes.Add(0);

			return bytes.ToArray();
		}
	}
}
