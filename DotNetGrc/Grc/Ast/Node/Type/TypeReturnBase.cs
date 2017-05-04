using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Type
{
	public abstract class TypeReturnBase : NodeBase
	{
		private string keyword;

		private int line;
		private int pos;

		public override string Text { get { return keyword; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public TypeReturnBase(string keyword, int line, int pos)
		{
			this.keyword = keyword;

			this.line = line;
			this.pos = pos;
		}
	}
}
