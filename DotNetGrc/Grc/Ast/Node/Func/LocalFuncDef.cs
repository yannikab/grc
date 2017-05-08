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

		public LocalFuncDecl Header { get { return header; } }

		public IReadOnlyList<LocalBase> Locals { get { return locals; } }

		public StmtBlock Block { get { return block; } }

		public override int Line { get { return header.Line; } }

		public override int Pos { get { return header.Pos; } }

		public LocalFuncDef()
		{
			this.locals = new List<LocalBase>();
		}

		public override void AddChild(NodeBase c)
		{
			if (header == null)
			{
				if (c is LocalFuncDecl)
					header = (LocalFuncDecl)c;
				else
					throw new NodeException();
			}
			else if (block == null)
			{
				if (c is LocalBase)
					locals.Add(c as LocalBase);
				else if (c is StmtBlock)
					block = (StmtBlock)c;
				else
					throw new NodeException();
			}
			else
			{
				throw new NodeException();
			}

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(header.Text);

			foreach (LocalBase l in locals)
				sb.AppendLine(l.Text);

			sb.Append(block.Text);

			return sb.ToString();
		}

		public override string ToString()
		{
			return "def: " + header.Name + "()";
		}
	}
}
