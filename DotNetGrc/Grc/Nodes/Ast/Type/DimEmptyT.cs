using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Type
{
	public class DimEmptyT : NodeBase
	{
		private readonly string lbrack;
		private readonly string rbrack;

		private readonly int line;
		private readonly int pos;

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

		public override string Text
		{
			get { return string.Format("{0}{1}", lbrack, rbrack); }
		}
	}
}
