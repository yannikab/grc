using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Expr
{
	public abstract class ExprLValBase : ExprBase
	{
		private int line;
		private int pos;

		public int Line { get { return line; } }
		public int Pos { get { return pos; } }
		public string Location { get { return string.Format("[{0}, {1}]", line, pos); } }

		public ExprLValBase(string text, int line, int pos)
			: base(text)
		{
			this.line = line;
			this.pos = pos;
		}
	}
}
