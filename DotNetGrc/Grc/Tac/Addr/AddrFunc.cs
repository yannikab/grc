﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Addr
{
	public class AddrFunc : AddrSym
	{
		private readonly string name;

		public AddrFunc(string name)
		{
			this.name = name;
		}

		public override string Name
		{
			get { return name; }
		}
		
		public override bool Equals(object obj)
		{
			AddrFunc that = obj as AddrFunc;

			if (that == null)
				return false;

			return this.name == that.name;
		}

		public override int GetHashCode()
		{
			return name.GetHashCode();
		}
	}
}