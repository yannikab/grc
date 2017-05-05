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

		public ExprLValBase Lval { get { return lval; } }

		public ExprBase Expr { get { return expr; } }

		public override int Line { get { return lval.Line; } }

		public override int Pos { get { return lval.Pos; } }

		public ExprLValIndexed(string lbrack, string rbrack)
		{
			this.lbrack = lbrack;
			this.rbrack = rbrack;
		}

		public override void AddChild(NodeBase c)
		{
			if (lval == null)
			{
				if (c is ExprLValBase)
					lval = (ExprLValBase)c;
				else
					throw new NodeException();
			}
			else if (expr == null)
			{
				if (c is ExprBase)
					expr = (ExprBase)c;
				else
					throw new NodeException();
			}
			else
			{
				throw new NodeException();
			}

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("{0}{1}{2}{3}", lval.Text, lbrack, expr.Text, rbrack);
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", lbrack, rbrack);
		}
	}
}
