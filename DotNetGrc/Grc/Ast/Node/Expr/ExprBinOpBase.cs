using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public abstract class ExprBinOpBase : ExprBase
	{
		private ExprBase left;
		private ExprBase right;

		private string oper;

		public ExprBase Left { get { return left; } }

		public ExprBase Right { get { return right; } }

		public override int Line { get { return left.Line; } }

		public override int Pos { get { return left.Pos; } }

		public ExprBinOpBase(string oper)
		{
			this.oper = oper;
		}

		public override void AddChild(NodeBase c)
		{
			if (!(c is ExprBase))
				throw new NodeException();

			if (left == null)
				left = (ExprBase)c;
			else if (right == null)
				right = (ExprBase)c;
			else
				throw new NodeException();

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("({0} {1} {2})", left.Text, oper, right.Text);
		}

		public override string ToString()
		{
			return oper;
		}
	}
}
