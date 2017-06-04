using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Type
{
	public class DimIntegerT : NodeBase
	{
		private readonly string integer;

		private readonly string lbrack;
		private readonly string rbrack;

		private readonly int line;
		private readonly int pos;

		public string Integer { get { return integer; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public DimIntegerT(string integer, string lbrack, string rbrack, int line, int pos)
		{
			this.integer = integer;
			this.lbrack = lbrack;
			this.rbrack = rbrack;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("{0}{1}{2}", lbrack, integer, rbrack); }
		}
	}
}
