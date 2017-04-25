using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	class CondNot : CondBase
	{
		private CondBase cond;

		public virtual CondBase Cond
		{
			get { return this.cond; }
			set { this.cond = value; }
		}

		public CondNot(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
