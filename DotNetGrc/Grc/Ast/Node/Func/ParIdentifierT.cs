using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	public class ParIdentifierT : NodeBase
	{
		private string id;

		private int line;
		private int pos;

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public ParIdentifierT(string id, int line, int pos)
		{
			this.id = id;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return id;
		}
	}
}
