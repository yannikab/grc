using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprPlus : ExprBase
	{
		private readonly ExprBase expr;

		private readonly string operPlus;

		private readonly int line;
		private readonly int pos;

		public ExprBase Expr { get { return expr; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprPlus(ExprBase expr, string operPlus, int line, int pos)
		{
			this.expr = expr;

			this.operPlus = operPlus;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("({0} {1})", operPlus, expr.Text);
		}

		public override string ToString()
		{
			return operPlus;
		}
	}
}
