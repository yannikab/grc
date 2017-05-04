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
		private TypeReturnBase returnType;

		public TypeReturnBase ReturnType
		{
			get { ProcessChildren(); return returnType; }
		}

		public override string Text
		{
			get { ProcessChildren(); return returnType.Text; }
		}

		public override int Line
		{
			get { ProcessChildren(); return returnType.Line; }
		}

		public override int Pos
		{
			get { ProcessChildren(); return returnType.Pos; }
		}

		public HTypeReturn()
		{
		}

		protected override void ProcessChildren()
		{
			if (returnType != null)
				return;

			if (Children.Count > 1)
				throw new NodeException("Return type must have one child.");

			returnType = (TypeReturnBase)Children[0];
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
