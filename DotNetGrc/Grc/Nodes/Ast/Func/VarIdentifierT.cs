using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Func
{
	public class VarIdentifierT : NodeBase
	{
		private readonly string id;

		private readonly int line;
		private readonly int pos;

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public VarIdentifierT(string id, int line, int pos)
		{
			this.id = id;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return id; }
		}
	}
}
