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

		public virtual ExprLValBase Lval
		{
			get { return this.lval; }
			set { this.lval = value; }
		}

		public virtual ExprBase Expr
		{
			get { return this.expr; }
			set { this.expr = value; }
		}

		public ExprLValIndexed(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
