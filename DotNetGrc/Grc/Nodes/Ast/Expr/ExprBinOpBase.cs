using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Expr
{
	public abstract partial class ExprBinOpBase : ExprBase
	{
		private readonly ExprBase left;
		private readonly ExprBase right;

		private readonly string oper;

		public ExprBase Left { get { return left; } }

		public ExprBase Right { get { return right; } }

		public override int Line { get { return left.Line; } }

		public override int Pos { get { return left.Pos; } }

		protected ExprBinOpBase(ExprBase left, ExprBase right, string oper)
		{
			this.left = left;
			this.right = right;

			this.oper = oper;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("({0} {1} {2})", left.Text, oper, right.Text); }
		}

		public override string ToString()
		{
			return oper;
		}
	}
}
