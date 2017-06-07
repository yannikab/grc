﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Tac.Addr
{
	public class AddrString : AddrBase
	{
		private readonly string s;

		public AddrString(string s)
		{
			this.s = s;
		}

		public override string ToString()
		{
			return s;
		}
	}
}