using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	public class CondNot : CondBase
	{
		private CondBase cond;

		private string operNot;

		public CondBase Cond
		{
			get { ProcessChildren(); return cond; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("({0} {1})", operNot, cond);
			}
		}

		public override int Line
		{
			get { ProcessChildren(); return cond.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return cond.Pos; }
		}

		public CondNot(string operNot)
		{
			this.operNot = operNot;
		}

		protected override void ProcessChildren()
		{
			if (cond != null)
				return;

			if (Children.Count > 1)
				throw new NodeException("Logical NOT condition must have one child.");

			cond = (CondBase)Children[0];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return operNot;
		}
	}
}
