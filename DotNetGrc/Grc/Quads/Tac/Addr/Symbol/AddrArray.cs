using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public partial class AddrArray : AddrSym
	{
		public AddrArray(AddrTmp elemAddr)
			: base(string.Format("[{0}]", elemAddr.Name), elemAddr.Type)
		{
		}
	}
}
