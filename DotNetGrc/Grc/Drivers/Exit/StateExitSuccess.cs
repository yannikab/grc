using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drivers
{
	class StateExitSuccess : StateBase
	{
		public override void HandleArgument(ArgumentContext context, string arg)
		{
			//System.Console.ReadLine();

			Environment.Exit(0);
		}
	}
}
