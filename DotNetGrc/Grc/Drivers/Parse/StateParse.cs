using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drivers
{
	class StateParse : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			switch (arg)
			{
				case "cst":

					context.State = new StateParseCst();

					break;

				case "ast":

					context.State = new StateParseAst();

					break;

				case "help":

					ShowHelp();

					context.State = new StateExitSuccess();

					break;

				default:

					ShowUsage();

					context.State = new StateExitFailure();

					break;
			}
		}

		private void ShowHelp()
		{
			Console.WriteLine("Available actions for module 'parse':");
			Console.WriteLine("cst - construct concrete syntax tree by parsing input");
			Console.WriteLine("ast - construct abstract syntax tree from concrete syntax tree");
		}

		private void ShowUsage()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.WriteLine("Available actions for module 'parse': cst, ast, help");
		}
	}
}
