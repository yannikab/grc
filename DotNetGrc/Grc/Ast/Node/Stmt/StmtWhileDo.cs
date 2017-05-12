using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtWhileDo : StmtBase
	{
		private CondBase cond;
		private StmtBase stmt;

		private string keyWhile;
		private string keyDo;

		private int line;
		private int pos;

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
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return string.Format("{0} {1} {2} {3}", keyWhile, cond.Text, keyDo, stmt.Text);
		}

		public override string ToString()
		{
			return string.Format("{0}-{1}", keyWhile, keyDo);
		}
	}
}
