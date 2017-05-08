using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public class GTypeFunction : GTypeBase
	{
		private GTypeBase from;
		private GTypeBase to;

		public GTypeBase From { get { return from; } }

		public GTypeBase To { get { return to; } }

		public GTypeFunction(GTypeBase from, GTypeBase to)
		{
			this.from = from;
			this.to = to;
		}

		public override bool Equals(object obj)
		{
			GTypeFunction that;

			if ((that = obj as GTypeFunction) == null)
				return false;

			return object.Equals(this.from, that.from) && object.Equals(this.to, that.to);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (from != null ? from.GetHashCode() : 0) + (to != null ? to.GetHashCode() : 0);
		}
	}
}
