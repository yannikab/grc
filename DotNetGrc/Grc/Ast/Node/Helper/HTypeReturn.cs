using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Node.Helper
{
	public class HTypeReturn : NodeBase
	{
		private readonly TypeReturnBase returnType;

		public TypeReturnBase ReturnType { get { return returnType; } }

		public override int Line { get { return returnType.Line; } }

		public override int Pos { get { return returnType.Pos; } }

		public HTypeReturn(TypeReturnBase returnType)
		{
			this.returnType = returnType;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get { return returnType.Text; }
		}
	}
}
