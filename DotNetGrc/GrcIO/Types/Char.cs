using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc
{
	public static partial class IO
	{
		public static void PutChar(byte c)
		{
			Console.Write((char)c);
		}

		public static byte GetChar()
		{
			return 0;
		}

		public static int CharGetOrd(byte c)
		{
			return (int)c;
		}
	}
}
