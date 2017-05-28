using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	public partial class CondNot : CondBase
	{
		private CondBase cond;

		private string operNot;

		public CondBase Cond { get { return cond; } }

		public override int Line { get { return cond.Line; } }

		public override int Pos { get { return cond.Pos; } }

		public CondNot(CondBase cond, string operNot)
		{
			this.cond = cond;

			this.operNot = operNot;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("({0} {1})", operNot, cond);
		}

		public override string ToString()
		{
			return operNot;
		}
	}
}
