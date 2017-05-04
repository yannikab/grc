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
	public class LocalFuncDef : LocalBase
	{
		private LocalFuncDecl header;
		private List<LocalBase> locals;
		private StmtBlock block;

		private string text;

		public LocalFuncDecl Header
		{
			get { ProcessChildren(); return header; }
		}

		public IReadOnlyList<LocalBase> Locals
		{
			get { ProcessChildren(); return locals; }
		}

		public StmtBlock Block
		{
			get { ProcessChildren(); return block; }
		}

		public override string Text { get { ProcessChildren(); return text; } }

		public override int Line
		{
			get { ProcessChildren(); return header.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return header.Pos; }
		}

		public LocalFuncDef()
		{
		}

		protected override void ProcessChildren()
		{
			if (header != null || locals != null || block != null)
				return;

			this.locals = new List<LocalBase>();

			StringBuilder sb = new StringBuilder();

			header = (LocalFuncDecl)Children[0];

			sb.Append(header.Text);
			sb.Append(Environment.NewLine);

			for (int i = 1; i < Children.Count - 1; i++)
			{
				locals.Add((LocalBase)Children[i]);

				sb.Append((Children[i] as LocalBase).Text);
				sb.Append(Environment.NewLine);
			}

			block = (StmtBlock)Children[Children.Count - 1];

			sb.Append(block.Text);

			this.text = sb.ToString();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string ToString()
		{
			return "func-def";
		}
	}
}
