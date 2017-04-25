using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	class StmtIfThenElse : StmtBase
	{
		private CondBase cond;
		private StmtBase stmtThen;
		private StmtBase stmtElse;

		public virtual CondBase Cond
		{
			get { return this.cond; }
			set { this.cond = value; }
		}

		public virtual StmtBase StmtThen
		{
			get { return this.stmtThen; }
			set { this.stmtThen = value; }
		}

		public virtual StmtBase StmtElse
		{
			get { return this.stmtElse; }
			set { this.stmtElse = value; }
		}

		public StmtIfThenElse(string text) : base(text)
		{
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
