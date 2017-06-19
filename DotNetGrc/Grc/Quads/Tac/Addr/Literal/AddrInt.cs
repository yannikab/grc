using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrInt : AddrLit
	{
		private readonly int i;

		private readonly TypeBase type;

		public override TypeBase Type { get { return type; } }

		public AddrInt(int i)
		{
			this.i = i;

			this.type = new TypeInt();
		}

		public override string ToString()
		{
			return i.ToString();
		}
	}
}
