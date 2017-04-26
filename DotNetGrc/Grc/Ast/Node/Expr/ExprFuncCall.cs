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
			get { return this.id; }
			set { this.id = value; }
		}

		public virtual IReadOnlyList<ExprBase> Args
		{
			get { return this.args; }
		}

		public ExprFuncCall(string text) : base(text)
		{
			this.id = text;

			this.args = new List<ExprBase>();
		}

		public virtual void AddArg(ExprBase arg)
		{
			this.args.Add(arg);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
