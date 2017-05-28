using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	public partial class CondAnd : CondBase
	{
		private CondBase left;
		private CondBase right;

		private string operAnd;

		public CondBase Left { get { return left; } }

		public CondBase Right { get { return right; } }

		public override int Line { get { return left.Line; } }

		public override int Pos { get { return left.Pos; } }

		public CondAnd(CondBase left, CondBase right, string operAnd)
		{
			this.left = left;
			this.right = right;

			this.operAnd = operAnd;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("({0} {1} {2})", left, operAnd, right);
		}

		public override string ToString()
		{
			return operAnd;
		}
	}
}
