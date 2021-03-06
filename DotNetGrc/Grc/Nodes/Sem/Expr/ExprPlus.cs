﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Nodes.Expr
{
	public partial class ExprPlus : ExprBase
	{
		public override int? StaticInt
		{
			get
			{
				if (!Expr.StaticInt.HasValue)
					return null;

				return checked(Expr.StaticInt.Value);
			}
		}
	}
}
