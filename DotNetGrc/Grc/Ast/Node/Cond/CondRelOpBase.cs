using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	public abstract class CondRelOpBase : CondBase
	{
		private ExprBase left;
		private ExprBase right;

		private string oper;

		public ExprBase Left
		{
			get { ProcessChildren(); return left; }
		}

		public ExprBase Right
		{
			get { ProcessChildren(); return right; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("({0} {1} {2})", left.Text, oper, right.Text);
			}
		}

		public override int Line
		{
			get { ProcessChildren(); return left.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return left.Pos; }
		}

		public CondRelOpBase(string oper)
		{
			this.oper = oper;
		}

		protected override void ProcessChildren()
		{
			if (left != null || right != null)
				return;

			if (Children.Count > 2)
				throw new NodeException("Relational operator condition must have two children.");

			left = (ExprBase)Children[0];
			right = (ExprBase)Children[1];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return oper;
		}
	}
}
