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
		private string character;

		private int line;
		private int pos;

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

		protected override string GetText()
		{
			return character;
		}
	}
}
