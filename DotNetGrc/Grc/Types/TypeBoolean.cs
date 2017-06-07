using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public class TypeBoolean : TypeBase
	{
		private static TypeBoolean instance;

		public static TypeBoolean Instance { get { return instance ?? (instance = new TypeBoolean()); } }

		public override bool MatchesRef(TypeBase obj)
		{
			TypeBoolean that = obj as TypeBoolean;

			if (that == null)
				return false;

			if (!that.ByRef)
				return true;

			return ByRef;
		}

		public override TypeBase Clone()
		{
			return new TypeBoolean() { ByRef = this.ByRef };
		}
	}
}
