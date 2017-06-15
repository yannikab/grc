using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Quads.Addr
{
	public abstract partial class AddrSym : AddrExpr
	{
		private readonly string name;

		private readonly TypeBase type;

		public string Name { get { return name; } }

		public TypeBase Type { get { return type; } }

		protected AddrSym(string name, TypeBase type)
		{
			this.name = name;
			this.type = type;
		}

		public override bool Equals(object obj)
		{
			AddrSym that = obj as AddrSym;

			if (that == null)
				return false;

			return Equals(this.GetType(), that.GetType()) && this.name == that.name;
		}

		public override int GetHashCode()
		{
			return this.GetType().GetHashCode() + name.GetHashCode();
		}

		public override string ToString()
		{
			return name;
		}
	}
}
