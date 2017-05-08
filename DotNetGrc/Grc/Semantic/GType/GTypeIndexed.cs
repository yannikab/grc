using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeIndexed : GTypeBase
	{
		private GTypeBase indexedType;

		public GTypeBase IndexedType { get { return indexedType; } }

		public GTypeIndexed(GTypeBase indexedType)
		{
			this.indexedType = indexedType;
		}

		public override bool Equals(object obj)
		{
			GTypeIndexed that;

			if ((that = obj as GTypeIndexed) == null)
				return false;

			return object.Equals(this.indexedType, that.indexedType);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (indexedType != null ? indexedType.GetHashCode() : 0);
		}
	}
}
