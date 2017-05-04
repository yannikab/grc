using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	public class CondAnd : CondBase
	{
		private CondBase left;
		private CondBase right;

		private string operAnd;

		public CondBase Left
		{
			get { ProcessChildren(); return left; }
		}

		public CondBase Right
		{
			get { ProcessChildren(); return right; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("({0} {1} {2})", left, operAnd, right);
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

		public CondAnd(string operAnd)
		{
			this.operAnd = operAnd;
		}

		protected override void ProcessChildren()
		{
			if (left != null || right != null)
				return;

			if (Children.Count > 2)
				throw new NodeException("Logical AND condition must have two children.");

			left = (CondBase)Children[0];
			right = (CondBase)Children[1];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return operAnd;
		}
	}
}
