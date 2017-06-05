using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public class GTypeIndexed : GTypeBase
	{
		private readonly GTypeBase indexedType;
		private readonly int dim;

		public GTypeBase IndexedType { get { return indexedType; } }

		public int Dim { get { return dim; } }

		public bool InHeader { get; set; }

		public GTypeIndexed(int dim, GTypeBase indexedType)
		{
			this.indexedType = indexedType;
			this.dim = dim;

			ByRef = true;
		}

		public override bool Equals(object obj)
		{
			GTypeIndexed that = obj as GTypeIndexed;

			if (that == null)
				return false;

			if (!Equals(this.indexedType, that.indexedType))
				return false;

			if (this.InHeader && that.InHeader && this.dim != that.dim)
				return false;

			if (!(this.dim == that.dim || this.dim == 0 || that.dim == 0))
				return false;

			return true;
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

			if (!Equals(this, that))
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

		public override GTypeBase Clone()
		{
			return new GTypeIndexed(dim, indexedType.Clone()) { InHeader = this.InHeader };
		}
	}
}
