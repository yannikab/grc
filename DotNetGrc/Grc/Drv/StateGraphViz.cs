using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drv
{
	class StateGraphViz : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			switch (arg)
			{
				case "cstsimple":

					context.State = new StateGraphVizCst(true);

					break;

				case "cst":

					context.State = new StateGraphVizCst(false);

					break;

				case "ast":

					context.State = new StateGraphVizAst();

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
			Console.WriteLine("Available actions for module 'graphviz':");
			Console.WriteLine("cstsimple - output graphviz code for concrete syntax tree without tokens by parsing input");
			Console.WriteLine("cst - output graphviz code for concrete syntax tree including tokens by parsing input");
			Console.WriteLine("ast - output graphviz code for abstract syntax tree");
		}

		private void ShowUsage()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.WriteLine("Available actions for module 'graphviz': cstsimple, cst, ast, help");
		}
	}
}
