using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;
using Grc.Nodes.Func;

namespace Grc.Nodes.Helper
{
	public class Root : NodeBase
	{
		private LocalFuncDef program;

		public LocalFuncDef Program
		{
			get { return program; }
			set { program = value; }
		}

		public override int Line { get { return program != null ? program.Line : 0; } }

		public override int Pos { get { return program != null ? program.Pos : 0; } }

		public Root()
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return program != null ? program.Text : string.Empty; }
		}

		public override string ToString()
		{
			return "root";
		}
	}
}
