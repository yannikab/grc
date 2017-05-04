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

		private string lbrack;
		private string rbrack;

		public ExprLValBase Lval
		{
			get { ProcessChildren(); return lval; }
		}

		public ExprBase Expr
		{
			get { ProcessChildren(); return expr; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("{0}{1}{2}{3}", lval.Text, lbrack, expr.Text, rbrack);
			}
		}

		public override int Line
		{
			get { ProcessChildren(); return lval.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return lval.Pos; }
		}

		public ExprLValIndexed(string lbrack, string rbrack)
		{
			this.lbrack = lbrack;
			this.rbrack = rbrack;
		}

		protected override void ProcessChildren()
		{
			if (this.expr != null || this.lval != null)
				return;

			if (Children.Count > 2)
				throw new NodeException("Indexed l-value must have two children.");

			ExprLValBase lval = (ExprLValBase)Children[0];
			ExprBase expr = (ExprBase)Children[1];

			this.lval = lval;
			this.expr = expr;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", lbrack, rbrack);
		}
	}
}
