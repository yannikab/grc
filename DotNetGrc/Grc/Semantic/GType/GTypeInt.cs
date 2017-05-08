using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeInt : GTypeData
	{
		private static GTypeInt instance;

		public static GTypeInt Instance
		{
			get
			{
				if (instance == null)
					instance = new GTypeInt();

				return instance;
			}
		}

		private GTypeInt()
		{
		}
	}
}
