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
			this["Encoding.GetBytes"] = typeof(Encoding).GetMethod("GetBytes", new Type[] { typeof(string) });
			this["Encoding.GetString"] = typeof(Encoding).GetMethod("GetString", new Type[] { typeof(byte[]) });

			this["String.get_Length"] = typeof(String).GetMethod("get_Length");
			this["String.Replace"] = typeof(String).GetMethod("Replace", new Type[] { typeof(string), typeof(string) });

			this["Console.Write"] = typeof(Console).GetMethod("Write", new Type[] { typeof(string) });
		}
	}
}
