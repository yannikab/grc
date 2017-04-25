using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Func
{
	class LocalFuncDef : LocalBase
	{
		private LocalFuncDecl header;
		private List<Variable> vars;
		private LocalVarDef varDef;
		private List<LocalFuncDecl> funcDecls;
		private List<LocalFuncDef> funcDefs;
		private StmtBlock block;

		public virtual LocalFuncDecl Header
		{
			get { return this.header; }
			set { this.header = value; }
		}

		public virtual IList<Variable> Vars
		{
			get { return this.vars; }
		}

		public virtual LocalVarDef VarDef
		{
			get { return this.varDef; }
			set { this.varDef = value; }
		}

		public virtual IList<LocalFuncDecl> FuncDecls
		{
			get { return this.funcDecls; }
		}

		public virtual IList<LocalFuncDef> FuncDefs
		{
			get { return this.funcDefs; }
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

		public LocalFuncDef() : base("func-def")
		{
			this.vars = new List<Variable>();
			this.funcDefs = new List<LocalFuncDef>();
			this.funcDecls = new List<LocalFuncDecl>();
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}
	}
}
