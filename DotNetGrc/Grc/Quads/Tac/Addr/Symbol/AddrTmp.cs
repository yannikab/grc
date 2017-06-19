using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrTmp : AddrSym
	{
		private static int nextId;

		private readonly TypeBase type;

		public override TypeBase Type { get { return type; } }

		public AddrTmp(TypeBase type, bool byRef)
			: base(string.Format("${0}", (nextId++).ToString("D1")))
		{
			this.type = type.Clone();

			this.type.ByRef = byRef;
		}
	}
}
