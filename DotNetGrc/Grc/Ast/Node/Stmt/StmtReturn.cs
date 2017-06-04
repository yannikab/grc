using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtReturn : StmtBase
	{
		private readonly ExprBase expr;

		private readonly string keyReturn;
		private readonly string semicolon;

		private readonly int line;
		private readonly int pos;

		public ExprBase Expr { get { return expr; } }

		public override int Line { get { return line; } }
		public override int Pos { get { return pos; } }

		public StmtReturn(ExprBase expr, string keyReturn, String semicolon, int line, int pos)
		{
			this.expr = expr;

			this.keyReturn = keyReturn;
			this.semicolon = semicolon;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("{0}{1}{2}{3}{4}", Tabs, keyReturn, expr == null ? string.Empty : " " + expr.Text, semicolon, Environment.NewLine); }
		}

		public override string ToString()
		{
			return keyReturn;
		}
	}
}
