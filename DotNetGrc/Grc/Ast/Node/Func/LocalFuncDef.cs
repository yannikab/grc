using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	public partial class LocalFuncDef : LocalBase
	{
		private LocalFuncDecl header;
		private List<LocalBase> locals;
		private StmtBlock stmtBlock;

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
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(header.Text.Replace(";", String.Empty));

			foreach (LocalBase l in locals)
				sb.AppendLine(l.Text);

			sb.Append(stmtBlock.Text);

			return sb.ToString();
		}

		public override string ToString()
		{
			string s = header.Name.Remove(0, header.Name[0] == '_' ? 1 : 0).Replace(".", "." + Environment.NewLine);

			return string.Format("def:{0}{1}()", Environment.NewLine, s);
		}
	}
}
