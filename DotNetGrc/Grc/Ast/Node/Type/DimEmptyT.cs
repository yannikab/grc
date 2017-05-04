using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Type
{
	public class DimEmptyT : NodeBase
	{
		private string lbrack;
		private string rbrack;

		private int line;
		private int pos;

		public override string Text
		{
			get { return string.Format("{0}{1}", lbrack, rbrack); }
		}

		public override int Line { get { return line; } }
		public override int Pos { get { return pos; } }

		public DimEmptyT(string lbrack, string rbrack, int line, int pos)
		{
			this.lbrack = lbrack;
			this.rbrack = rbrack;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
