using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrChar : AddrLit
	{
		private readonly string text;

		private readonly TypeBase type;

		public override TypeBase Type { get { return type; } }

		public AddrChar(string text)
		{
			this.text = text;

			this.type = new TypeChar();
		}

		public override string ToString()
		{
			return text;
		}
	}
}
