using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Stmt
{
	public class StmtBlock : StmtBase
	{
		private List<StmtBase> stmts;

		public virtual IReadOnlyList<StmtBase> Stmts
		{
			get { return this.stmts; }
		}

		public StmtBlock(string text) : base(text)
		{
			this.stmts = new List<StmtBase>();
		}

		public virtual void AddStmt(StmtBase stmt)
		{
			this.stmts.Add(stmt);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
