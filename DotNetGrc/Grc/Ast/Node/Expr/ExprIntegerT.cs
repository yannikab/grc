using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public partial class ExprIntegerT : ExprBase
	{
		private readonly string integer;

		private readonly int line;
		private readonly int pos;

		public string Integer { get { return integer; } }

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

		public override string Text
		{
			get { return integer; }
		}
	}
}
