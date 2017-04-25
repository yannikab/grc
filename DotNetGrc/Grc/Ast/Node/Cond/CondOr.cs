using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	class CondOr : CondBase
	{
		private CondBase left;
		private CondBase right;

		public virtual CondBase Left
		{
			get { return this.left; }
			set { this.left = value; }
		}

		public virtual CondBase Right
		{
			get { return this.right; }
			set { this.right = value; }
		}

		public CondOr(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
