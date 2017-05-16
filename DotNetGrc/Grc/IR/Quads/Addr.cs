using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Quads
{
	public class Addr
	{
		private static int nextTemp;

		public static readonly Addr Empty;
		public static readonly Addr Star;

		static Addr()
		{
			nextTemp = 0;

			Empty = new Addr(" ");
			Star = new Addr("*");
		}

		private string val;

		public string Val { get { return val; } }

		public Addr(string addr)
		{
			this.val = addr;
		}

		public Addr(int addr)
			: this(addr.ToString())
		{
		}

		public Addr()
			: this(string.Format("_t{0}", (nextTemp++).ToString()))
		{
		}

		public override bool Equals(object obj)
		{
			Addr that = obj as Addr;
			if (that == null)
				return false;

			return object.Equals(this.val, that.val);
		}

		public override int GetHashCode()
		{
			return val.GetHashCode();
		}

		public override string ToString()
		{
			return val;
		}
	}
}
