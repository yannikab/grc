using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Driver
{
	class StateCode : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			switch (arg)
			{
				case "src":

					context.State = new StateCodeSrc();

					break;

				case "srcll":

					context.State = new StateCodeSrcLL();

					break;

				case "tac":

					context.State = new StateCodeTac();

					break;

				case "tacll":

					context.State = new StateCodeTacLL();

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
			Console.WriteLine("src - output reconstructed source code from abstract syntax tree");
			Console.WriteLine("srcll - output reconstructed source code after lambda lifting");
			Console.WriteLine("tac - output intermediate representation of input in three address code");
			Console.WriteLine("tacll - output intermediate representation after lambda lifting");
		}

		private void ShowUsage()
		{
			Console.WriteLine("Usage: grc [module] [action] [filename]");
			Console.WriteLine("Available actions for module 'code': src, srcll, tac, tacll, help");
		}
	}
}
