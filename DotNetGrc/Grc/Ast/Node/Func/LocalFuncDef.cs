using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Ast.Node.Func
{
	public class LocalFuncDef : LocalBase
	{
		private LocalFuncDecl header;
		private List<LocalBase> locals;
		private StmtBlock block;

		public virtual LocalFuncDecl Header
		{
			get { return this.header; }
			set { this.header = value; }
		}

		public virtual IReadOnlyList<LocalBase> Locals
		{
			get { return this.locals; }
		}

		public virtual StmtBlock Block
		{
			get { return this.block; }
			set { this.block = value; }
		}

		public virtual IReadOnlyList<StmtBase> Stmts
		{
			get { return this.block != null ? this.block.Stmts : null; }
		}

		public LocalFuncDef()
			: base("func-def")
		{
			this.locals = new List<LocalBase>();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public virtual void AddLocal(LocalBase local)
		{
			this.locals.Add(local);
		}
	}
}
