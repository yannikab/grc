using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtBlock : StmtBase
	{
		private List<StmtBase> stmts;

		private string lbrace;
		private string rbrace;

		private string text;

		private int line;
		private int pos;

		public IReadOnlyList<StmtBase> Stmts
		{
			get { ProcessChildren(); return stmts; }
		}

		public override string Text
		{
			get { ProcessChildren(); return text; }
		}

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtBlock(string lbrace, string rbrace, int line, int pos)
		{
			this.lbrace = lbrace;
			this.rbrace = rbrace;

			this.line = line;
			this.pos = pos;
		}

		protected override void ProcessChildren()
		{
			if (this.stmts != null)
				return;

			this.stmts = new List<StmtBase>(Children.Cast<StmtBase>());

			StringBuilder sb = new StringBuilder();

			sb.Append(lbrace);

			sb.Append(Environment.NewLine);

			for (int i = 0; i < stmts.Count; i++)
			{
				sb.Append(stmts[i].Text);
				sb.Append(Environment.NewLine);
			}

			sb.Append(rbrace);

			this.text = sb.ToString();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", lbrace, rbrace);
		}
	}
}
