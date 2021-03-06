﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Types;

namespace Grc.Symbols
{
	public abstract class SymbolBase
	{
		private readonly string name;
		private SymbolBase next;
		private int scopeId;
		private TypeBase type;

		public string Name
		{
			get { return name; }
		}

		public SymbolBase Next
		{
			get { return next; }
			set { next = value; }
		}

		public int ScopeId
		{
			get { return scopeId; }
			set { scopeId = value; }
		}

		public TypeBase Type
		{
			get { return type; }
			set { type = value; }
		}

		public SymbolBase(string name)
		{
			this.name = name;
		}

		public override bool Equals(object obj)
		{
			if (obj as SymbolBase == null)
				return false;

			SymbolBase that = (SymbolBase)obj;

			return this.name == that.name;
		}

		public override int GetHashCode()
		{
			int hash = 17;
			hash = 31 * hash + this.name.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			return string.Format("[ Name = {0} ]", this.name);
		}
	}
}
