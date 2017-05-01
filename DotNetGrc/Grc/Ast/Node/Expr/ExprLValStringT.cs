﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	class ExprLValStringT : ExprLValBase
	{
		public ExprLValStringT(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}