using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtAssign : StmtBase
	{
		private ExprLValBase lval;
		private ExprBase expr;

		private string operAssign;
		private string semicolon;

		public ExprLValBase Lval
		{
			get { ProcessChildren(); return this.lval; }
		}

		public ExprBase Expr
		{
			get { ProcessChildren(); return this.expr; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				return string.Format("{0} {1} {2}{3}", lval, operAssign, expr, semicolon);
			}
		}

		public override int Line
		{
			get { ProcessChildren(); return lval.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return lval.Pos; }
		}

		public StmtAssign(string operAssign, string semicolon)
		{
			this.operAssign = operAssign;
			this.semicolon = semicolon;
		}

		protected override void ProcessChildren()
		{
			if (lval != null || expr != null)
				return;

			if (Children.Count > 2)
				throw new NodeException("Assignment statement must have two children.");

			lval = (ExprLValBase)Children[0];
			expr = (ExprBase)Children[1];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return operAssign;
		}
	}
}
