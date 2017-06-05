﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public abstract class GTypeBase
	{
		public bool ByRef { get; set; }

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			return obj.GetType().Equals(GetType());
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode();
		}

		public override string ToString()
		{
			return GetType().Name;
		}

		public abstract bool MatchesRef(GTypeBase obj);

		public abstract GTypeBase Clone();
	}
}
