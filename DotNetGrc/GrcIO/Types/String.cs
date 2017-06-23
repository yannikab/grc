using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc
{
	public static partial class IO
	{
		public static unsafe void PutStr(byte* p)
		{
			byte c;

			int i = 0;

			while ((c = *(p + i++)) != 0)
				Console.Write((char)c);
		}

		public static unsafe void GetStr(int n, byte* p)
		{
			string s = System.Console.ReadLine();

			int i;

			for (i = 0; i < s.Length && i < n - 1; i++)
				*(p + i) = (byte)s[i];

			*(p + i) = (byte)'\0';
		}

		public static unsafe int StrLen(byte* p)
		{
			int i = 0;

			while (*(p + i++) != 0) ;

			return i - 1;
		}

		public static unsafe int StrCmp(byte* p1, byte* p2)
		{
			for (; *p1 != 0 && *p2 != 0 && *p1 == *p2; p1++, p2++) ;

			if (*p1 == 0 && *p2 == 0)
				return 0;
			else if (*p1 == 0)
				return -1;
			else if (*p2 == 0 || *p1 > *p2)
				return 1;
			else
				return -1;
		}

		public static unsafe void StrCpy(byte* p2, byte* p1)
		{
			return;
		}

		public static unsafe void StrCat(byte* p2, byte* p1)
		{
			return;
		}
	}
}
