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

		private int line;
		private int pos;

		public IReadOnlyList<StmtBase> Stmts { get { return stmts; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		public StmtBlock(string lbrace, string rbrace, int line, int pos)
		{
			this.lbrace = lbrace;
			this.rbrace = rbrace;

			this.line = line;
			this.pos = pos;

			this.stmts = new List<StmtBase>();
		}

		public override void AddChild(NodeBase c)
		{
			if (!(c is StmtBase))
				throw new NodeException();

			stmts.Add((StmtBase)c);

			base.AddChild(c);
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
