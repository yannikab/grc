using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Drivers
{
	class ArgumentContext
	{
		public StateBase State { get; set; }

		public ArgumentContext(StateBase state)
		{
			State = state;
		}

		public void HandleArgument(string arg)
		{
			if (State == null)
				return;

			State.HandleArgument(this, arg);
		}
	}
}
