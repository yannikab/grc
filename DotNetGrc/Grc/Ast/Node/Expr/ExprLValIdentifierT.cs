using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprLValIdentifierT : ExprLValBase
	{
		private string name;

		public string Name
		{
			get { return name; }
		}

		public ExprLValIdentifierT(string text)
			: base(text)
		{
			this.name = text;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
