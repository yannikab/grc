using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Visitor
{
	public class DepthFirstVisitor : VisitorAdapter
	{
		public virtual void DefaultPre(NodeBase n)
		{
		}

		public virtual void DefaultPost(NodeBase n)
		{
		}

		public virtual void Pre(Root n)
		{
			DefaultPre(n);
		}

		public virtual void Post(Root n)
		{
			DefaultPost(n);
		}

		public override void Visit(Root n)
		{
			Pre(n);

			n.Program.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprIntegerT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprIntegerT n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprIntegerT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprCharacterT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprCharacterT n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprCharacterT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprLValIdentifierT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprLValIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprLValIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprLValStringT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprLValStringT n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprLValStringT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(ExprLValIndexed n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprLValIndexed n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprLValIndexed n)
		{
			Pre(n);

			n.Lval.Accept(this);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprBinOpBase n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprBinOpBase n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprBinOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprPlus n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprPlus n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprPlus n)
		{
			Pre(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprMinus n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprMinus n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprMinus n)
		{
			Pre(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(ExprFuncCall n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ExprFuncCall n)
		{
			DefaultPost(n);
		}

		public override void Visit(ExprFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
				e.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondRelOpBase n)
		{
			DefaultPre(n);
		}

		public virtual void Post(CondRelOpBase n)
		{
			DefaultPost(n);
		}

		public override void Visit(CondRelOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondOr n)
		{
			DefaultPre(n);
		}

		public virtual void Post(CondOr n)
		{
			DefaultPost(n);
		}

		public override void Visit(CondOr n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondAnd n)
		{
			DefaultPre(n);
		}

		public virtual void Post(CondAnd n)
		{
			DefaultPost(n);
		}

		public override void Visit(CondAnd n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public virtual void Pre(CondNot n)
		{
			DefaultPre(n);
		}

		public virtual void Post(CondNot n)
		{
			DefaultPost(n);
		}

		public override void Visit(CondNot n)
		{
			Pre(n);

			n.Cond.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtNoOpT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtNoOpT n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtNoOpT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(StmtBlock n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtBlock n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtBlock n)
		{
			Pre(n);

			foreach (StmtBase s in n.Stmts)
				s.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtAssign n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtAssign n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtAssign n)
		{
			Pre(n);

			n.Lval.Accept(this);

			n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtIfThen n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtIfThen n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtIfThen n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.Stmt.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtIfThenElse n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtIfThenElse n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtIfThenElse n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.StmtThen.Accept(this);

			n.StmtElse.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtWhileDo n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtWhileDo n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtWhileDo n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.Stmt.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtFuncCall n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtFuncCall n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
				e.Accept(this);

			Post(n);
		}

		public virtual void Pre(StmtReturn n)
		{
			DefaultPre(n);
		}

		public virtual void Post(StmtReturn n)
		{
			DefaultPost(n);
		}

		public override void Visit(StmtReturn n)
		{
			Pre(n);

			if (n.Expr != null)
				n.Expr.Accept(this);

			Post(n);
		}

		public virtual void Pre(LocalFuncDef n)
		{
			DefaultPre(n);
		}

		public virtual void Post(LocalFuncDef n)
		{
			DefaultPost(n);
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			n.Header.Accept(this);

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			n.Block.Accept(this);

			Post(n);
		}

		public virtual void Pre(LocalFuncDecl n)
		{
			DefaultPre(n);
		}

		public virtual void Post(LocalFuncDecl n)
		{
			DefaultPost(n);
		}

		public override void Visit(LocalFuncDecl n)
		{
			Pre(n);

			foreach (HPar h in n.HPars)
				h.Accept(this);

			n.HTypeReturn.Accept(this);

			Post(n);
		}

		public virtual void Pre(HPar n)
		{
			DefaultPre(n);
		}

		public virtual void Post(HPar n)
		{
			DefaultPost(n);
		}

		public override void Visit(HPar n)
		{
			Pre(n);

			foreach (ParIdentifierT id in n.Identifiers)
				id.Accept(this);

			n.HTypePar.Accept(this);

			Post(n);
		}

		public virtual void Pre(ParIdentifierT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(ParIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Visit(ParIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(HTypePar n)
		{
			DefaultPre(n);
		}

		public virtual void Post(HTypePar n)
		{
			DefaultPost(n);
		}

		public override void Visit(HTypePar n)
		{
			Pre(n);

			n.DataType.Accept(this);

			if (n.DimEmpty != null)
				n.DimEmpty.Accept(this);

			foreach (DimIntegerT d in n.Dims)
				d.Accept(this);

			Post(n);
		}

		public virtual void Pre(TypeDataBase n)
		{
			DefaultPre(n);
		}

		public virtual void Post(TypeDataBase n)
		{
			DefaultPost(n);
		}

		public override void Visit(TypeDataBase n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(DimEmptyT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(DimEmptyT n)
		{
			DefaultPost(n);
		}

		public override void Visit(DimEmptyT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(DimIntegerT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(DimIntegerT n)
		{
			DefaultPost(n);
		}

		public override void Visit(DimIntegerT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(LocalVarDef n)
		{
			DefaultPre(n);
		}

		public virtual void Post(LocalVarDef n)
		{
			DefaultPost(n);
		}

		public override void Visit(LocalVarDef n)
		{
			Pre(n);

			foreach (VarIdentifierT id in n.Identifiers)
				id.Accept(this);

			n.HTypeVar.Accept(this);

			Post(n);
		}

		public virtual void Pre(HTypeReturn n)
		{
			DefaultPre(n);
		}

		public virtual void Post(HTypeReturn n)
		{
			DefaultPost(n);
		}

		public override void Visit(HTypeReturn n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(TypeReturnNothingT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(TypeReturnNothingT n)
		{
			DefaultPost(n);
		}

		public override void Visit(TypeReturnNothingT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(VarIdentifierT n)
		{
			DefaultPre(n);
		}

		public virtual void Post(VarIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Visit(VarIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public virtual void Pre(HTypeVar n)
		{
			DefaultPre(n);
		}

		public virtual void Post(HTypeVar n)
		{
			DefaultPost(n);
		}

		public override void Visit(HTypeVar n)
		{
			Pre(n);

			n.DataType.Accept(this);

			foreach (DimIntegerT d in n.Dims)
				d.Accept(this);

			Post(n);
		}
	}
}
