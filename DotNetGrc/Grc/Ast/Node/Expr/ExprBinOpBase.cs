using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	abstract class ExprBinOpBase : ExprBase
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

		public ExprBinOpBase(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
