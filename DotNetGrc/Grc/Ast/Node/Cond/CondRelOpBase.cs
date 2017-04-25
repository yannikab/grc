using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Cond
{
	abstract class CondRelOpBase : CondBase
	{
		private ExprBase left;
		private ExprBase right;

		public virtual ExprBase Left
		{
			get { return this.left; }
			set { this.left = value; }
		}

		public virtual ExprBase Right
		{
			get { return this.right; }
			set { this.right = value; }
		}

		public CondRelOpBase(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
