using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprPlus : ExprBase
	{
		private ExprBase expr;

		string operPlus;

		private int line;
		private int pos;

		public ExprBase Expr { get { return expr; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprPlus(string operPlus, int line, int pos)
		{
			this.operPlus = operPlus;

			this.line = line;
			this.pos = pos;
		}

		public override void AddChild(NodeBase c)
		{
			if (expr != null || (expr = c as ExprBase) == null)
				throw new NodeException();

			base.AddChild(c);
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
