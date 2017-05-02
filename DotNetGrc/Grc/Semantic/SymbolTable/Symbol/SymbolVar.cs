﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Semantic.SymbolTable.Symbol
{
	public class SymbolVar : SymbolBase
	{
		public SymbolVar(string name)
			: base(name)
		{
		}

		public override bool Equals(object obj)
		{
			if (obj as SymbolVar == null)
				return false;

			SymbolVar that = (SymbolVar)obj;

			return base.Equals(that);
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = 31 * hash + base.GetHashCode();
			return hash;
		}
	}
}