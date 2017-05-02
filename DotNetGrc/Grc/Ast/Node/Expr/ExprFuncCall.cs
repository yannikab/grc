using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Expr
{
	public class ExprFuncCall : ExprBase
	{
		private string name;
		private List<ExprBase> args;

		public virtual string Name
		{
			get { return this.name; }
		}

		public virtual IReadOnlyList<ExprBase> Args
		{
			get { return this.args; }
		}

		public ExprFuncCall(string text)
			: base(text)
		{
			this.name = text.Replace("()", "");

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
