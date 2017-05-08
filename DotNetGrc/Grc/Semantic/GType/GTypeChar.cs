using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeChar : GTypeData
	{
		private static GTypeChar instance;

		public static GTypeChar Instance
		{
			get
			{
				if (instance == null)
					instance = new GTypeChar();

				return instance;
			}
		}

		private GTypeChar()
		{
		}
	}
}
