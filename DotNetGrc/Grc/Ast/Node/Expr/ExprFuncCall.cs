using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	class ExprFuncCall : ExprBase
	{
		private string id;
		private List<ExprBase> args;

		public virtual string Id
		{
			get { return id; }
			set { this.id = value; }
		}

		public virtual IReadOnlyList<ExprBase> Args
		{
			get { return args; }
		}

		public ExprFuncCall(string text) : base(text)
		{
			this.id = text;

			this.args = new List<ExprBase>();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
