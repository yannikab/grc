﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprIntegerT : ExprBase
	{
		public override int? StaticInt
		{
			get { return int.Parse(Integer); }
		}
	}
}
