using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtIfThenElse : StmtBase
	{
		private readonly CondBase cond;
		private readonly StmtBase stmtThen;
		private readonly StmtBase stmtElse;

		private readonly string keyIf;
		private readonly string keyThen;
		private readonly string keyElse;

		private readonly int line;
		private readonly int pos;

		public CondBase Cond { get { return cond; } }

		public StmtBase StmtThen { get { return stmtThen; } }

		public StmtBase StmtElse { get { return stmtElse; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtIfThenElse(CondBase cond, StmtBase stmtThen, StmtBase stmtElse, string keyIf, string keyThen, string keyElse, int line, int pos)
		{
			this.cond = cond;
			this.stmtThen = stmtThen;
			this.stmtElse = stmtElse;

			this.keyIf = keyIf;
			this.keyThen = keyThen;
			this.keyElse = keyElse;

			this.line = line;
			this.pos = pos;

			this.stmtThen.Parent = this;
			this.stmtElse.Parent = this;
		}

		public override void Accept(IVisitor v)
		{
			string s = this.Text;
			v.Visit(this);
		}

		public override string Text
		{
			get
			{
				return string.Format("{0}{1} {2} {3}{4}{5}{6}{7}{8}{9}",
					Tabs, keyIf, cond.Text, keyThen, Environment.NewLine, stmtThen.Text,
					Tabs, keyElse, Environment.NewLine, stmtElse.Text);
			}
		}

		public override string ToString()
		{
			return string.Format("{0}-{1}-{2}", keyIf, keyThen, keyElse);
		}
	}
}
