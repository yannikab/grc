using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drv
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				ArgumentContext context = new ArgumentContext(new StateModule());

				for (int i = 0; i < args.Length; i++)
					context.HandleArgument(args[i]);

				context.HandleArgument(null);
			}
			catch (Exception e)
			{
				System.Console.WriteLine(string.Format("{0}:", e.GetType().Name));
				System.Console.WriteLine(e.Message);

				Environment.Exit(1);
			}
		}
	}
}
