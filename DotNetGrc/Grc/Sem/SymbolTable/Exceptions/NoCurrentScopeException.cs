﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.SymbolTable.Exceptions
{
	public class NoCurrentScopeException : SymbolTableException
	{
		public NoCurrentScopeException()
			: base("No current scope.")
		{
		}
	}
}