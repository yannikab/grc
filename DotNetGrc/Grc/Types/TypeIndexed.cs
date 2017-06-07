using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public class TypeIndexed : TypeBase
	{
		private readonly TypeBase indexedType;
		private readonly int dim;

		public TypeBase IndexedType { get { return indexedType; } }

		public int Dim { get { return dim; } }

		public bool InHeader { get; set; }

		public TypeIndexed(int dim, TypeBase indexedType)
		{
			this.indexedType = indexedType;
			this.dim = dim;

			ByRef = true;
		}

		public override bool Equals(object obj)
		{
			TypeIndexed that = obj as TypeIndexed;

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

		public override bool MatchesRef(TypeBase obj)
		{
			TypeIndexed that = obj as TypeIndexed;

			if (that == null)
				return false;

			if (!Equals(this, that))
				return false;

			return true;
		}

		private void TypeString(out string type, out string dims)
		{
			if (indexedType is TypeIndexed)
			{
				string indexedDims;
				(indexedType as TypeIndexed).TypeString(out type, out indexedDims);
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

		public override TypeBase Clone()
		{
			return new TypeIndexed(dim, indexedType.Clone()) { InHeader = this.InHeader };
		}
	}
}
