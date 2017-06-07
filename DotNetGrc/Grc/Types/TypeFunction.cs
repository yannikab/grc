using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public class TypeFunction : TypeBase
	{
		private readonly TypeBase from;
		private readonly TypeBase to;

		public TypeBase From { get { return from; } }

		public TypeBase To { get { return to; } }

		public TypeFunction(TypeBase from, TypeBase to)
		{
			this.from = from;
			this.to = to;
		}

		public override bool Equals(object obj)
		{
			TypeFunction that = obj as TypeFunction;

			if (that == null)
				return false;

			return Equals(this.from, that.from) && Equals(this.to, that.to);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (from != null ? from.GetHashCode() : 0) + (to != null ? to.GetHashCode() : 0);
		}

		public override bool MatchesRef(TypeBase obj)
		{
			TypeFunction that = obj as TypeFunction;

			if (that == null)
				return false;

			if (!Equals(this, that))
				return false;

			return this.From.MatchesRef(that.From);
		}

		public override string ToString()
		{
			return string.Format("{0} <- {1}", to, from);
		}

		public override TypeBase Clone()
		{
			return new TypeFunction(from.Clone(), to.Clone());
		}
	}
}
