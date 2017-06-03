using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtIfThen : StmtBase
	{
		private readonly CondBase cond;
		private readonly StmtBase stmt;

		private readonly string keyIf;
		private readonly string keyThen;

		private readonly int line;
		private readonly int pos;

		public CondBase Cond { get { return cond; } }

		public StmtBase Stmt { get { return stmt; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtIfThen(CondBase cond, StmtBase stmt, string keyIf, string keyThen, int line, int pos)
		{
			this.cond = cond;
			this.stmt = stmt;

			this.keyIf = keyIf;
			this.keyThen = keyThen;

			this.line = line;
			this.pos = pos;

			stmt.Parent = this;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("{0}{1} {2} {3}{4}{5}",
				Tabs, keyIf, cond.Text, keyThen, Environment.NewLine, stmt.Text);
		}

		public override string ToString()
		{
			return string.Format("{0}-{1}", keyIf, keyThen);
		}
	}
}
