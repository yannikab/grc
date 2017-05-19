using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drv
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

				default:

					ShowActions();

					context.State = new StateExitFailure();

					break;
			}
		}

		private void ShowActions()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.Write("Available actions for module parse: cst, ast, help");
		}
	}
}
