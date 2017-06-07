using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Expr
{
	public class ExprLValStringT : ExprLValBase
	{
		private string str;

		private readonly int line;
		private readonly int pos;

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

		public override string Text
		{
			get { return str; }
		}
	}
}
