﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.Types
{
	public class GTypeChar : GTypeData
	{
		public override bool MatchesRef(GTypeBase obj)
		{
			if (!Equals(this, obj))
				return false;

			if (!obj.ByRef)
				return true;

			return ByRef;
		}

		public override string ToString()
		{
			return string.Format("{0}{1}", ByRef ? "ref " : string.Empty, "char");
		}

		public override GTypeBase Clone()
		{
			return new GTypeChar() { ByRef = this.ByRef };
		}
	}
}
