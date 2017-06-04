using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Type
{
	public abstract class TypeReturnBase : NodeBase
	{
		private readonly string keyword;

		private readonly int line;
		private readonly int pos;

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public TypeReturnBase(string keyword, int line, int pos)
		{
			this.keyword = keyword;

			this.line = line;
			this.pos = pos;
		}

		public override string Text
		{
			get { return keyword; }
		}
	}
}
