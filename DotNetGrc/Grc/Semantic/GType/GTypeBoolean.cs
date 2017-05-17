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
					instance = new GTypeBoolean(false);

				return instance;
			}
		}

		private GTypeBoolean(bool byRef)
			: base(byRef)
		{
		}

		public override bool MatchesRef(GTypeBase obj)
		{
			GTypeBoolean that = obj as GTypeBoolean;

			if (that == null)
				return false;

			if (!that.ByRef)
				return true;

			return ByRef;
		}
	}
}
