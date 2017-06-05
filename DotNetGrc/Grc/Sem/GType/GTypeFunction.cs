﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public class GTypeFunction : GTypeBase
	{
		private readonly GTypeBase from;
		private readonly GTypeBase to;

		public GTypeBase From { get { return from; } }

		public GTypeBase To { get { return to; } }

		public GTypeFunction(GTypeBase from, GTypeBase to)
		{
			this.from = from;
			this.to = to;
		}

		public override bool Equals(object obj)
		{
			GTypeFunction that = obj as GTypeFunction;

			if (that == null)
				return false;

			return Equals(this.from, that.from) && Equals(this.to, that.to);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() + (from != null ? from.GetHashCode() : 0) + (to != null ? to.GetHashCode() : 0);
		}

		public override bool MatchesRef(GTypeBase obj)
		{
			GTypeFunction that = obj as GTypeFunction;

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

		public override GTypeBase Clone()
		{
			return new GTypeFunction(from.Clone(), to.Clone());
		}
	}
}
