﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Sem.SymbolTable.Exceptions
{
	public abstract class SymbolTableException : ApplicationException
	{
		public SymbolTableException(string message)
			: base(message)
		{
		}
	}
}