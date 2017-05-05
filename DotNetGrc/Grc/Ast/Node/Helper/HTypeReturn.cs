﻿using System;
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

		public TypeReturnBase ReturnType { get { return returnType; } }

		public override int Line { get { return returnType.Line; } }

		public override int Pos { get { return returnType.Pos; } }

		public HTypeReturn()
		{
		}

		public override void AddChild(NodeBase c)
		{
			if (returnType != null || (returnType = c as TypeReturnBase) == null)
				throw new NodeException();

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			return returnType.Text;
		}
	}
}
