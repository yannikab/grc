﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	class CondNe : CondRelOpBase
	{
		public CondNe(string operNe)
			: base(operNe)
		{
		}
	}
}
