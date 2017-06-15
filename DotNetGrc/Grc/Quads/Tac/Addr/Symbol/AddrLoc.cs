using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Quads.Addr
{
	public partial class AddrLoc : AddrVar
	{
		public AddrLoc(ExprLValIdentifierT id)
			: base(id.Name, id.Type)
		{
		}
	}
}
