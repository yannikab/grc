﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	class CondEq : CondRelOpBase
	{
		public CondEq(string text) : base(text)
		{
		}
	}
}
