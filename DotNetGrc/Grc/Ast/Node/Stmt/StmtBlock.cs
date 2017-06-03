using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;
using Grc.Ast.Node.Func;

namespace Grc.Ast.Node.Stmt
{
	public partial class StmtBlock : StmtBase
	{
		private readonly List<StmtBase> stmts;

		private readonly string lbrace;
		private readonly string rbrace;

		private readonly int line;
		private readonly int pos;

		public IReadOnlyList<StmtBase> Stmts { get { return stmts; } }

		public override int Line { get { return line; } }

		public override int Pos { get { return pos; } }

		protected override int Indent { get { return Parent is StmtBlock ? base.Indent : base.Indent - 1; } }

		public StmtBlock(List<StmtBase> stmts, string lbrace, string rbrace, int line, int pos)
		{
			this.stmts = stmts;

			this.lbrace = lbrace;
			this.rbrace = rbrace;

			this.line = line;
			this.pos = pos;

			foreach (StmtBase s in stmts)
				s.Parent = this;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(Tabs);
			sb.AppendLine(lbrace);

			for (int i = 0; i < stmts.Count; i++)
			{
				if (i != 0 && (stmts[i] is StmtBlock || stmts[i] is StmtIfThen || stmts[i] is StmtIfThenElse || stmts[i] is StmtWhileDo))
					sb.AppendLine();

				sb.Append(stmts[i].Text);

				if (i != stmts.Count - 1 &&
					((stmts[i] is StmtBlock || stmts[i] is StmtIfThen || stmts[i] is StmtIfThenElse || stmts[i] is StmtWhileDo) &&
					!(stmts[i + 1] is StmtBlock || stmts[i + 1] is StmtIfThen || stmts[i + 1] is StmtIfThenElse || stmts[i + 1] is StmtWhileDo)))
					sb.AppendLine();
			}

			sb.Append(Tabs);
			sb.Append(rbrace);

			if (!(Parent is LocalFuncDef))
				sb.AppendLine();

			return sb.ToString();
		}

		public override string ToString()
		{
			return string.Format("{0} {1}", lbrace, rbrace);
		}
	}
}
