using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Quads.Addr
{
	public class AddrTemp : AddrSym
	{
		private static int nextId;

		private readonly int id;

		public AddrTemp()
		{
			this.id = nextId++;
		}

		public override string Name
		{
			get { return string.Format("${0}", id); }
		}

		public override bool Equals(object obj)
		{
			AddrTemp that = obj as AddrTemp;

			if (that == null)
				return false;

			return this.id == that.id;
		}

		public override int GetHashCode()
		{
			return id.GetHashCode();
		}
	}
}
