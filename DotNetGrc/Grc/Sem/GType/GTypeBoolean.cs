using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public class GTypeBoolean : GTypeBase
	{
		private static GTypeBoolean instance;

		public static GTypeBoolean Instance { get { return instance ?? (instance = new GTypeBoolean()); } }

		public override bool MatchesRef(GTypeBase obj)
		{
			GTypeBoolean that = obj as GTypeBoolean;

			if (that == null)
				return false;

			if (!that.ByRef)
				return true;

			return ByRef;
		}

		public override GTypeBase Clone()
		{
			return new GTypeBoolean() { ByRef = this.ByRef };
		}
	}
}
