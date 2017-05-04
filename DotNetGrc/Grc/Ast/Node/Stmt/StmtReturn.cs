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

		private string keyReturn;
		private string semicolon;

		private int line;
		private int pos;

		public ExprBase Expr
		{
			get { ProcessChildren(); return expr; }
		}

		public override string Text
		{
			get
			{
				ProcessChildren();

				if (expr != null)
					return string.Format("{0} {1}{2}", keyReturn, expr.Text, semicolon);
				else
					return string.Format("{0}{1}", keyReturn, semicolon);
			}
		}

		public override int Line { get { return line; } }
		public override int Pos { get { return pos; } }

		public StmtReturn(string keyReturn, String semicolon, int line, int pos)
		{
			this.keyReturn = keyReturn;
			this.semicolon = semicolon;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (expr != null)
				return;

			if (Children.Count > 1)
				throw new NodeException("Return statement must have one child at most");

			expr = Children.Count == 1 ? (ExprBase)Children[0] : null;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return keyReturn;
		}
	}
}
