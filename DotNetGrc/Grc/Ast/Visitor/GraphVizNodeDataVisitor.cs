using System;
using System.Collections.Generic;
using Grc.Ast.Node;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Node.Type;

namespace Grc.Ast.Visitor
{
	class GraphVizNodeDataVisitor : VisitorAdapter
	{
		private IDictionary<NodeBase, int?> id = new Dictionary<NodeBase, int?>();

		private int nextId = 0;

		private Stack<NodeBase> stack = new Stack<NodeBase>();

		private void AddString(string s)
		{
			int i = nextId++;

			Console.WriteLine("\t" + GvName(i) + " ;");
			Console.WriteLine("\t" + GvName(i) + " [label=\"" + GvData(s) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(id[stack.Peek()].Value) + " -- " + GvName(i));
		}

		private string GvName(int id)
		{
			return string.Format("n{0:D4}", id);
		}

		private string GvData(string text)
		{
			return text.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("[", "\\[").Replace("]", "\\]");
		}

		private void Pre(NodeBase n)
		{
			if (!id.ContainsKey(n))
				id[n] = nextId++;

			Console.WriteLine("\t" + GvName(id[n].Value) + " ;");
			Console.WriteLine("\t" + GvName(id[n].Value) + " [label=\"" + GvData(n.ToString()) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(id[stack.Peek()].Value) + " -- " + GvName(id[n].Value));

			stack.Push(n);
		}

		private void Post(NodeBase n)
		{
			stack.Pop();
		}

		public override void Visit(Root n)
		{
			Console.WriteLine("graph\n{");

			// Pre(n);

			if (n.Children.Count == 1)
				n.Children[0].Accept(this);

			// Post(n);

			Console.WriteLine("}");
		}

		public override void Visit(ExprIntegerT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(ExprCharacterT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(ExprLValIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(ExprLValStringT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(ExprLValIndexed n)
		{
			Pre(n);

			n.Lval.Accept(this);

			n.Expr.Accept(this);

			Post(n);
		}

		public override void Visit(ExprBinOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public override void Visit(ExprPlus n)
		{
			Pre(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public override void Visit(ExprMinus n)
		{
			Pre(n);

			n.Expr.Accept(this);

			Post(n);
		}

		public override void Visit(ExprFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
				e.Accept(this);

			Post(n);
		}

		public override void Visit(CondRelOpBase n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public override void Visit(CondOr n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public override void Visit(CondAnd n)
		{
			Pre(n);

			n.Left.Accept(this);

			n.Right.Accept(this);

			Post(n);
		}

		public override void Visit(CondNot n)
		{
			Pre(n);

			n.Cond.Accept(this);

			Post(n);
		}

		public override void Visit(StmtNoOpT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(StmtBlock n)
		{
			Pre(n);

			foreach (StmtBase s in n.Stmts)
				s.Accept(this);

			Post(n);
		}

		public override void Visit(StmtAssign n)
		{
			Pre(n);

			n.Lval.Accept(this);

			n.Expr.Accept(this);

			Post(n);
		}

		public override void Visit(StmtIfThen n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.Stmt.Accept(this);

			Post(n);
		}

		public override void Visit(StmtIfThenElse n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.StmtThen.Accept(this);

			n.StmtElse.Accept(this);

			Post(n);
		}

		public override void Visit(StmtWhileDo n)
		{
			Pre(n);

			n.Cond.Accept(this);

			n.Stmt.Accept(this);

			Post(n);
		}

		public override void Visit(StmtFuncCall n)
		{
			Pre(n);

			foreach (ExprBase e in n.Args)
				e.Accept(this);

			Post(n);
		}

		public override void Visit(StmtReturn n)
		{
			Pre(n);

			if (n.Expr != null)
				n.Expr.Accept(this);

			Post(n);
		}

		public override void Visit(HRef n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(HVal n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(FParIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(LocalVarDef n)
		{
			Pre(n);

			if (n.Parent is LocalFuncDef)
				foreach (Variable v in ((LocalFuncDef)n.Parent).Vars)
					AddString(v.ToString());

			Post(n);
		}

		public override void Visit(VarIdentifierT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(HType n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			n.Header.Accept(this);

			if (n.VarDef != null)
				n.VarDef.Accept(this);

			foreach (LocalBase l in n.FuncDecls)
				l.Accept(this);

			foreach (LocalBase l in n.FuncDefs)
				l.Accept(this);

			n.Block.Accept(this);

			Post(n);
		}

		public override void Visit(LocalFuncDecl n)
		{
			Pre(n);

			foreach (Parameter p in n.Params)
				AddString(p.ToString());

			n.ReturnType.Accept(this);

			Post(n);
		}

		public override void Visit(TypeDataBase n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(TypeReturnNothingT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(DimEmptyT n)
		{
			Pre(n);

			Post(n);
		}

		public override void Visit(DimIntegerT n)
		{
			Pre(n);

			Post(n);
		}
	}
}
