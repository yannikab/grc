using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtBlock : StmtBase
	{
		private List<StmtBase> stmts;

		private string lbrace;
		private string rbrace;

		private int line;
		private int pos;

		public IReadOnlyList<StmtBase> Stmts { get { return stmts; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtBlock(List<StmtBase> stmts, string lbrace, string rbrace, int line, int pos)
		{
			this.stmts = stmts;

			this.lbrace = lbrace;
			this.rbrace = rbrace;

			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(lbrace);

			foreach (StmtBase s in stmts)
				sb.AppendLine(s.Text);

			sb.Append(rbrace);

			return sb.ToString();
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", lbrace, rbrace);
		}
	}
}
