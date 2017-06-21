using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc
{
	public static partial class IO
	{
		public static void PutInt(int i)
		{
			Console.Write(i);
		}

		public static int GetInt()
		{
			return 0;
		}

		public static byte IntGetChar(int i)
		{
			return (byte)i;
		}

		public static int IntGetAbs(int i)
		{
			if (i > 0)
				return i;
			else if (i < 0)
				return -1;
			else
				return 0;
		}
	}
}
