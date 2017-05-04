using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprIntegerT : ExprBase
	{
		private string integer;

		private int line;
		private int pos;

		public string Integer { get { return integer; } }

		public override string Text { get { return integer; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprIntegerT(string integer, int line, int pos)
		{
			this.integer = integer;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
