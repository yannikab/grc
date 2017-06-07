using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drivers
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

				case "gv":

					context.State = new StateGraphViz();

					break;

				case "type":

					context.State = new StateType();

					break;

				case "code":

					context.State = new StateCode();

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
			Console.WriteLine("Available modules:");
			Console.WriteLine("lex - lexical analysis of input");
			Console.WriteLine("parse - syntax analysis after lexical analysis");
			Console.WriteLine("gv - output graphviz code for concrete and abstract syntax trees");
			Console.WriteLine("type - type checking after syntax analysis and semantic checking");
			Console.WriteLine("code - code generation after type checking");
		}

		private void ShowUsage()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.WriteLine("Available modules: lex, parse, gv, type, code, help");
		}
	}
}
