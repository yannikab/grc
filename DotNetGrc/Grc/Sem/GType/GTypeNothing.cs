using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public class GTypeNothing : GTypeReturn
	{
		private static GTypeNothing instance;

		public static GTypeNothing Instance { get { return instance ?? (instance = new GTypeNothing()); } }

		private GTypeNothing()
		{
		}

		public override bool MatchesRef(GTypeBase obj)
		{
			return Equals(this, obj);
		}

		public override string ToString()
		{
			return "nothing";
		}

		public override GTypeBase Clone()
		{
			return this;
		}
	}
}
