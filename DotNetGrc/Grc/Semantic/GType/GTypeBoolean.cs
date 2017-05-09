using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeBoolean : GTypeBase
	{
		private static GTypeBoolean instance;

		public static GTypeBoolean Instance
		{
			get
			{
				if (instance == null)
					instance = new GTypeBoolean();

				return instance;
			}
		}

		private GTypeBoolean()
		{
		}
	}
}
