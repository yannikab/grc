using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeInt : GTypeData
	{
		public GTypeInt(bool byRef)
			: base(byRef)
		{
		}

		public override bool MatchesRef(GTypeBase obj)
		{
			GTypeInt that = obj as GTypeInt;

			if (that == null)
				return false;

			if (!that.ByRef)
				return true;

			return ByRef;
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", ByRef ? "ref " : string.Empty, "int");
		}
	}
}
