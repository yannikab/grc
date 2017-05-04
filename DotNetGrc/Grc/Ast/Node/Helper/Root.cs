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

		public LocalFuncDef Program
		{
			get { ProcessChildren(); return program; }
		}

		public override string Text
		{
			get { ProcessChildren(); return program.ToString(); }
		}

		public override int Line { get { ProcessChildren(); return program.Line; } }

		public override int Pos { get { ProcessChildren(); return program.Pos; } }

		public Root()
		{
		}

		protected override void ProcessChildren()
		{
			if (program != null)
				return;

			if (Children.Count > 1)
				throw new NodeException("Root node must have one child.");

			this.program = (LocalFuncDef)Children[0];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
