using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public class GTypeIndexed : GTypeBase
	{
		private GTypeBase indexedType;
		private int dim;

		public GTypeBase IndexedType { get { return indexedType; } }

		public int Dim { get { return dim; } }

		public GTypeIndexed(int dim, GTypeBase indexedType)
			: base(true)
		{
			this.indexedType = indexedType;

			this.dim = dim;
		}

		public override bool Equals(object obj)
		{
			GTypeIndexed that = obj as GTypeIndexed;

			if (that == null)
				return false;

			return object.Equals(this.indexedType, that.indexedType);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (indexedType != null ? indexedType.GetHashCode() : 0);
		}

		public override bool MatchesRef(GTypeBase obj)
		{
			GTypeIndexed that = obj as GTypeIndexed;

			if (that == null)
				return false;

			if (!object.Equals(this, that))
				return false;

			return true;
		}

		private void TypeString(out string type, out string dims)
		{
			if (indexedType is GTypeIndexed)
			{
				string indexedDims;
				(indexedType as GTypeIndexed).TypeString(out type, out indexedDims);
				dims = string.Format("[{0}]{1}", dim, indexedDims);
			}
			else
			{
				type = indexedType.ToString();
				dims = string.Format("[{0}]", dim);
			}
		}

		public override string ToString()
		{
			string type;
			string dims;

			TypeString(out type, out dims);

			return string.Format("{0} {1}", type, dims);
		}
	}
}
