using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drv
{
	class StateModule : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			switch (arg)
			{
				case "lex":

					context.State = new StateLex();

					break;

				case "parse":

					context.State = new StateParse();

					break;

				case "graphviz":

					context.State = new StateGraphViz();

					break;

				case "type":

					context.State = new StateType();

					break;

				case "code":

					context.State = new StateCode();

					break;

				case "help":
				default:

					ShowModules();

					context.State = new StateExitFailure();

					break;
			}
		}

		private void ShowModules()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.Write("Available modules: lex, parse, graphviz, type, help");
		}
	}
}
