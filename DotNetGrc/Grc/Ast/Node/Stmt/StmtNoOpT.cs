﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtNoOpT : StmtBase
	{
		private readonly string semicolon;

		private readonly int line;
		private readonly int pos;

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtNoOpT(string semicolon, int line, int pos)
		{
			this.semicolon = semicolon;
			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("{0}{1}{2}", Tabs, semicolon, Environment.NewLine);
		}
	}
}
