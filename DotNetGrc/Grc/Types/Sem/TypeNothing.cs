using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Types
{
	public class TypeNothing : TypeReturn
	{
		private static TypeNothing instance;

		public static TypeNothing Instance { get { return instance ?? (instance = new TypeNothing()); } }

		private TypeNothing()
		{
		}

		public override bool MatchesRef(TypeBase obj)
		{
			return Equals(this, obj);
		}

		public override string ToString()
		{
			return "nothing";
		}

		public override TypeBase Clone()
		{
			return this;
		}
	}
}
