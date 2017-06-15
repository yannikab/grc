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

		public AddrTmp(TypeBase type)
			: base(string.Format("${0}", (nextId++).ToString("D1")), type)
		{
		}
	}
}
