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

				default:

					ShowActions();

					context.State = new StateExitFailure();

					break;
			}
		}

		private void ShowActions()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.Write("Available actions for module graphviz: cstsimple, cst, ast, help");
		}
	}
}
