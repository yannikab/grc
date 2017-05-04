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

		string operMinus;

		private int line;
		private int pos;

		public ExprBase Expr
		{
			get { ProcessChildren(); return expr; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("({0} {1})", operMinus, expr.Text);
			}
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprMinus(string operMinus, int line, int pos)
		{
			this.operMinus = operMinus;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (expr != null)
				return;

			if (Children.Count > 1)
				throw new NodeException("Unary minus expression must have one child.");

			expr = (ExprBase)Children[0];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return operMinus;
		}
	}
}
