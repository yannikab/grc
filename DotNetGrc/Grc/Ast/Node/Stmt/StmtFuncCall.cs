using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtFuncCall : StmtBase
	{
		private string name;
		private List<ExprBase> args;

		public virtual string Name
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public virtual IReadOnlyList<ExprBase> Args
		{
			get { return this.args; }
		}

		public StmtFuncCall()
			: base("()")
		{
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

		public override string ToString()
		{
			return name;
		}
	}
}
