using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtAssign : StmtBase
	{
		private ExprLValBase lval;
		private ExprBase expr;

		private string operAssign;
		private string semicolon;

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

		protected override string GetText()
		{
			return string.Format("{0} {1} {2}{3}", lval.Text, operAssign, expr.Text, semicolon);
		}

		public override string ToString()
		{
			return operAssign;
		}
	}
}
