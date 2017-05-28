using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.IR.Quads
{
	public class Addr : IComparable
	{
		private static int nextTemp;

		public static readonly Addr Empty;
		public static readonly Addr Star;
		public static readonly Addr ByRef;
		public static readonly Addr ByVal;
		public static readonly Addr Ret;
		public static readonly Addr RetVal;

		static Addr()
		{
			nextTemp = 0;

			Empty = new Addr("_");
			Star = new Addr("*");
			ByRef = new Addr("R");
			ByVal = new Addr("V");
			Ret = new Addr("RET");
			RetVal = new Addr("$$");
		}

		private int id;

		private string addr;

		public string Value { get { return addr; } }

		public Addr(string addr)
		{
			this.addr = addr;
		}

		public Addr(int id)
			: this(id.ToString())
		{
			this.id = id;
		}

		public Addr()
			: this(string.Format("${0}", (nextTemp++).ToString()))
		{
		}

		public override bool Equals(object obj)
		{
			Addr that = obj as Addr;
			if (that == null)
				return false;

			return object.Equals(this.addr, that.addr);
		}

		public override int GetHashCode()
		{
			return addr.GetHashCode();
		}

		public override string ToString()
		{
			return addr;
		}

		public int CompareTo(object obj)
		{
			Addr that = obj as Addr;

			if (that == null)
				return -1;

			if (this.id > that.id)
				return 1;
			else if (this.id < that.id)
				return -1;
			else
				return 0;
		}
	}
}
