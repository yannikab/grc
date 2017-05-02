using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtReturn : StmtBase
	{
		private ExprBase expr;

		public virtual ExprBase Expr
		{
			get { return this.expr; }
			set { this.expr = value; }
		}

		public StmtReturn(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
