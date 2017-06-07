using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Cond;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Stmt
{
	public partial class StmtWhileDo : StmtBase
	{
		private readonly CondBase cond;
		private readonly StmtBase stmt;

		private readonly string keyWhile;
		private readonly string keyDo;

		private readonly int line;
		private readonly int pos;

		public CondBase Cond { get { return cond; } }

		public StmtBase Stmt { get { return stmt; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtWhileDo(CondBase cond, StmtBase stmt, string keyWhile, string keyDo, int line, int pos)
		{
			this.cond = cond;
			this.stmt = stmt;

			this.keyWhile = keyWhile;
			this.keyDo = keyDo;

			this.line = line;
			this.pos = pos;

			this.stmt.Parent = this;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return string.Format("{0}{1} {2} {3}{4}{5}", Tabs, keyWhile, cond.Text, keyDo, Environment.NewLine, stmt.Text); }
		}

		public override string ToString()
		{
			return string.Format("{0}-{1}", keyWhile, keyDo);
		}
	}
}
