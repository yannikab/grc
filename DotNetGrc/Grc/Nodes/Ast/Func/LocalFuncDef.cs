using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Func
{
	public partial class LocalFuncDef : LocalBase
	{
		private readonly LocalFuncDecl header;
		private readonly List<LocalBase> locals;
		private readonly StmtBlock stmtBlock;

		public LocalFuncDecl Header { get { return header; } }

		public IReadOnlyList<LocalBase> Locals { get { return locals; } }

		public StmtBlock Block { get { return stmtBlock; } }

		public override int Line { get { return header.Line; } }

		public override int Pos { get { return header.Pos; } }

		public LocalFuncDef(LocalFuncDecl header, List<LocalBase> locals, StmtBlock stmtBlock)
		{
			this.header = header;
			this.locals = locals;
			this.stmtBlock = stmtBlock;

			this.header.Parent = this;

			foreach (NodeBase n in locals)
				n.Parent = this;

			this.stmtBlock.Parent = this;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.AppendLine(header.Text.Remove(header.Text.Length - 1, 1));

				if (locals.Count > 0)
					sb.AppendLine();

				foreach (LocalBase l in locals)
				{
					sb.AppendLine(l.Text);

					if (l != locals[locals.Count - 1])
						sb.AppendLine();
				}

				sb.Append(stmtBlock.Text);

				return sb.ToString();
			}
		}

		public override string ToString()
		{
			string s = header.Name
				.Remove(0, header.Name[0] == '_' ? (header.Name.Length > 1 && header.Name[1] == '.' ? 2 : 1) : 0)
				.Replace(".", "." + Environment.NewLine);

			return string.Format("def:{0}{1}()", Environment.NewLine, s);
		}
	}
}
