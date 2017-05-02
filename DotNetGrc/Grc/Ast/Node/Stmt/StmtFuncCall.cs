using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtFuncCall : StmtBase
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

		public StmtFuncCall(ExprFuncCall funcall)
			: base(funcall.Text)
		{
			this.name = funcall.Name;
			this.args = new List<ExprBase>(funcall.Args);

			this.line = funcall.Line;
			this.pos = funcall.Pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
