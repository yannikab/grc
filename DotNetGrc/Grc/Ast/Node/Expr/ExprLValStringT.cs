using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprLValStringT : ExprLValBase
	{
		private string str;

		private int line;
		private int pos;

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprLValStringT(string str, int line, int pos)
		{
			this.str = str;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return str;
		}
	}
}
