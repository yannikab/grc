using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drv
{
	class StateCode : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			switch (arg)
			{
				case "source":

					context.State = new StateParseSource();

					break;

				case "tac":

					context.State = new StateCodeTAC();

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
			Console.WriteLine("Available actions for module 'code':");
			Console.WriteLine("source - output reconstructed source code from abstract syntax tree"); 
			Console.WriteLine("tac - output intermediate representation of input in three address code");
		}

		private void ShowUsage()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.WriteLine("Available actions for module 'code': source, tac, help");
		}
	}
}
