using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrLoc : AddrVar
	{
		private readonly TypeBase type;

		public override TypeBase Type { get { return type; } }

		public AddrLoc(string name, TypeBase type, bool byRef)
			: base(name)
		{
			this.type = type.Clone();

			this.type.ByRef = byRef;
		}
	}
}
