using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprCharacterT : ExprBase
	{
		private readonly string character;

		private readonly int line;
		private readonly int pos;

		public string Character { get { return character; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ExprCharacterT(string character, int line, int pos)
		{
			this.character = character;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return character; }
		}
	}
}
