using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.Types
{
	public abstract class GTypeBase
	{
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			return obj.GetType().Equals(this.GetType());
		}

		public override int GetHashCode()
		{
			return GetType().GetHashCode();
		}

		public override string ToString()
		{
			return GetType().Name;
		}
	}
}
