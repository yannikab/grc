using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	class StmtIfThen : StmtBase
	{
		private CondBase cond;
		private StmtBase stmt;

		public virtual CondBase Cond
		{
			get { return this.cond; }
			set { this.cond = value; }
		}

		public virtual StmtBase Stmt
		{
			get { return this.stmt; }
			set { this.stmt = value; }
		}

		public StmtIfThen(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
