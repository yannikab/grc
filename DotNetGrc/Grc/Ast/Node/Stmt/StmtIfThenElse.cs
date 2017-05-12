using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtIfThenElse : StmtBase
	{
		private CondBase cond;
		private StmtBase stmtThen;
		private StmtBase stmtElse;

		private string keyIf;
		private string keyThen;
		private string keyElse;

		private int line;
		private int pos;

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
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("{0} {1} {2} {3} {4} {5}",
					keyIf, cond.Text, keyThen, stmtThen.Text, keyElse, stmtElse.Text);
		}

		public override string ToString()
		{
			return string.Format("{0}-{1}-{2}", keyIf, keyThen, keyElse);
		}
	}
}
