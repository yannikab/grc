using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprCharacterT : ExprBase
	{
		private int line;
		private int pos;

		public ExprCharacterT(string text, int line, int pos)
			: base(text)
		{
			this.line = line;
			this.pos = pos;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
