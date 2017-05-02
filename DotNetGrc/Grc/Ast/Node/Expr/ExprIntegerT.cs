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
		private int line;
		private int pos;

		public int Line { get { return line; } }
		public int Pos { get { return pos; } }
		public string Location { get { return string.Format("[{0}, {1}]", line, pos); } }

		public ExprIntegerT(string text, int line, int pos)
			: base(text)
		{
			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
