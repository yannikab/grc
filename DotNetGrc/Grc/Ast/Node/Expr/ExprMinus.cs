using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprMinus : ExprBase
	{
		private ExprBase expr;

		public virtual ExprBase Expr
		{
			get { return this.expr; }
			set { this.expr = value; }
		}

		public ExprMinus(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
