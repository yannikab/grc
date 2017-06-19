using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public partial class AddrString : AddrLit
	{
		private readonly string text;

		private TypeIndexed type;

		public string Text { get { return text; } }

		public override TypeBase Type { get { return type; } }

		public AddrString(string text)
		{
			this.text = text.Substring(1, text.Length - 2);

			this.type = new TypeIndexed(this.text.Length + 1, new TypeChar());
		}

		public override string ToString()
		{
			return string.Format("\"{0}\"", text);
		}
	}
}
