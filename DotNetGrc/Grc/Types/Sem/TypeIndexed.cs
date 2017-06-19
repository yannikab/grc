using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Sem;

namespace Grc.Types
{
	public partial class TypeIndexed : TypeBase
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

		public int TotalDims
		{
			get
			{
				TypeIndexed typeIndexed = indexedType as TypeIndexed;

				return typeIndexed == null ? 1 : typeIndexed.TotalDims + 1;
			}
		}

		public int GetDim(int dim)
		{
			if (dim < 0 || dim > TotalDims - 1)
				throw new SemanticException("Invalid dimension index");

			TypeIndexed typeIndexed = this;

			for (int i = 0; i < dim; i++)
				typeIndexed = (TypeIndexed)typeIndexed.indexedType;

			return typeIndexed.Dim;
		}

		public int TotalElements
		{
			get
			{
				int totalElements = 1;

				TypeIndexed typeIndexed = this;

				do
				{
					totalElements *= typeIndexed.Dim;

					typeIndexed = typeIndexed.IndexedType as TypeIndexed;

				} while (typeIndexed != null);

				return totalElements;
			}
		}

		public TypeBase ElementType
		{
			get
			{
				TypeBase type = indexedType;

				TypeIndexed typeIndexed = indexedType as TypeIndexed;

				while (typeIndexed != null)
				{
					type = typeIndexed.indexedType;

					typeIndexed = typeIndexed.indexedType as TypeIndexed;
				}

				return type;
			}
		}
	}
}
