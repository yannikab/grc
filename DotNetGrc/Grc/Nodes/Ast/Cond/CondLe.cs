﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;

namespace Grc.Nodes.Cond
{
	public partial class CondLe : CondRelOpBase
	{
		public CondLe(ExprBase left, ExprBase right, string operLe)
			: base(left, right, operLe)
		{
		}
	}
}
