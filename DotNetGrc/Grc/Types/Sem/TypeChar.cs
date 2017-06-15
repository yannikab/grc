using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public partial class TypeChar : TypeData
	{
		public override bool MatchesRef(TypeBase obj)
		{
			if (!Equals(this, obj))
				return false;

			if (!obj.ByRef)
				return true;

			return ByRef;
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", ByRef ? "ref " : string.Empty, "char");
		}

		public override TypeBase Clone()
		{
			return new TypeChar() { ByRef = this.ByRef };
		}
	}
}
