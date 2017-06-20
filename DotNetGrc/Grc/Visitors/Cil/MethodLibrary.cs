using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Grc.Visitors.Cil
{
	public class MethodLibrary : Dictionary<string, MethodInfo>
	{
		private static MethodLibrary instance;

		public static MethodLibrary Instance
		{
			get
			{
				if (instance == null)
					instance = new MethodLibrary();

				return instance;
			}
		}

		private MethodLibrary()
		{
			this["Encoding.get_ASCII"] = typeof(Encoding).GetMethod("get_ASCII");
			this["Encoding.get_Unicode"] = typeof(Encoding).GetMethod("get_Unicode");
			this["Encoding.GetBytes"] = typeof(Encoding).GetMethod("GetBytes", new Type[] { typeof(string) });
			this["Encoding.GetString"] = typeof(Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) });

			this["String.get_Length"] = typeof(String).GetMethod("get_Length");
			this["String.Replace"] = typeof(String).GetMethod("Replace", new Type[] { typeof(string), typeof(string) });

			this["Array.get_Length"] = typeof(Array).GetMethod("get_Length");

			this["Console.set_OutputEncoding"] = typeof(Console).GetMethod("set_OutputEncoding", new Type[] { typeof(Encoding) });
			this["Console.WriteInt"] = typeof(Console).GetMethod("Write", new Type[] { typeof(int) });
			this["Console.WriteChar"] = typeof(Console).GetMethod("Write", new Type[] { typeof(char) });
			this["Console.WriteString"] = typeof(Console).GetMethod("Write", new Type[] { typeof(string) });
			
			this["Object.ToString"] = typeof(Object).GetMethod("ToString", new Type[] { });
		}
	}
}
