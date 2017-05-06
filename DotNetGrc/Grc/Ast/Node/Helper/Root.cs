using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;
using Grc.Ast.Node.Func;

namespace Grc.Ast.Node.Helper
{
	public class Root : NodeBase
	{
		private LocalFuncDef program;

		public LocalFuncDef Program { get { return program; } }

		public override int Line { get { return program.Line; } }

		public override int Pos { get { return program.Pos; } }

		public Root()
		{
		}

		public override void AddChild(NodeBase c)
		{
			if (program != null || (program = c as LocalFuncDef) == null)
				throw new NodeException();

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return program.Text;
		}

		public override string ToString()
		{
			return "root";
		}
	}
}
