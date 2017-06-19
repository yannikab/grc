using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrArray : AddrSym
	{
		private readonly AddrTmp elemAddr;

		public override TypeBase Type { get { return elemAddr.Type; } }

		public AddrArray(AddrTmp elemAddr)
			: base(string.Format("[{0}]", elemAddr.Name))
		{
			this.elemAddr = elemAddr;
		}
	}
}
