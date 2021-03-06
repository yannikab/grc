﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Stmt
{
	public partial class StmtAssign : StmtBase
	{
		private readonly ExprLValBase lval;
		private readonly ExprBase expr;

		private readonly string operAssign;
		private readonly string semicolon;

		public ExprLValBase Lval { get { return this.lval; } }

		public ExprBase Expr { get { return this.expr; } }

		public override int Line { get { return lval.Line; } }

		public override int Pos { get { return lval.Pos; } }

		public StmtAssign(ExprLValBase lval, ExprBase expr, string operAssign, string semicolon)
		{
			this.lval = lval;
			this.expr = expr;

			this.operAssign = operAssign;
			this.semicolon = semicolon;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("{0}{1} {2} {3}{4}{5}", Tabs, lval.Text, operAssign, expr.Text, semicolon, Environment.NewLine); }
		}

		public override string ToString()
		{
			return operAssign;
		}
	}
}
