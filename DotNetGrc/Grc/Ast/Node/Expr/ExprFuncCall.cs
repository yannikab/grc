using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprFuncCall : ExprBase
	{
		private string name;
		private List<ExprBase> args;

		private int line;
		private int pos;

		public string Name { get { return name; } }
		public IReadOnlyList<ExprBase> Args { get { return args; } }

		public int Line { get { return line; } }
		public int Pos { get { return pos; } }
		public string Location { get { return string.Format("[{0}, {1}]", line, pos); } }

		public ExprFuncCall(string text, IEnumerable<ExprBase> args, int line, int pos)
			: base(text)
		{
			this.name = text.Replace("()", "");
			this.args = new List<ExprBase>(args);

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
