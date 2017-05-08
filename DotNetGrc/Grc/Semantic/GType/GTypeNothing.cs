using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeNothing : GTypeReturn
	{
		private static GTypeNothing instance;

		public static GTypeNothing Instance
		{
			get
			{
				if (instance == null)
					instance = new GTypeNothing();

				return instance;
			}
		}

		private GTypeNothing()
		{
		}
	}
}
