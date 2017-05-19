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
				case "ir":

					context.State = new StateCodeIR();

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
			Console.Write("Available actions for module code: ir, help");
		}
	}
}
