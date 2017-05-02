using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprLValIndexed : ExprLValBase
	{
		private ExprLValBase lval;
		private ExprBase expr;

		public ExprLValBase Lval { get { return lval; } }
		public ExprBase Expr { get { return expr; } }

		public ExprLValIndexed(string text, ExprLValBase lval, ExprBase expr)
			: base(text, lval.Line, lval.Pos)
		{
			this.lval = lval;
			this.expr = expr;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
