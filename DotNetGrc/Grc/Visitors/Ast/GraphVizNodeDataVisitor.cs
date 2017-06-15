using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Nodes.Expr;
using Grc.Nodes.Cond;

namespace Grc.Visitors.Ast
{
	class GraphVizNodeDataVisitor : DepthFirstVisitor
	{
		private int nextId = 0;

		private Stack<int> stack = new Stack<int>();

		private void AddString(string s)
		{
			int i = nextId++;

			Console.WriteLine("\t" + GvName(i) + " ;");
			Console.WriteLine("\t" + GvName(i) + " [label=\"" + GvData(s) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(stack.Peek()) + " -- " + GvName(i));
		}

		private string GvName(int id)
		{
			return string.Format("n{0:D4}", id);
		}

		private string GvData(string text)
		{
			return text.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("[", "\\[").Replace("]", "\\]");
		}

		public void DefaultPre(NodeBase n)
		{
			int i = nextId++;

			Console.WriteLine("\t" + GvName(i) + " ;");
			Console.WriteLine("\t" + GvName(i) + " [label=\"" + GvData(n.ToString()) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(stack.Peek()) + " -- " + GvName(i));

			stack.Push(i);
		}

		public void DefaultPost(NodeBase n)
		{
			stack.Pop();
		}

		public override void Pre(Root n)
		{
			Console.WriteLine("graph\n{");
		}

		public override void Post(Root n)
		{
			Console.WriteLine("}");
		}

		public override void Visit(HTypePar n)
		{
			AddString(n.Text);
		}

		public override void Visit(HTypeVar n)
		{
			AddString(n.Text);
		}

		public override void Visit(StmtFuncCall n)
		{
			Visit(n.FunCall);
		}

		public override void Pre(LocalFuncDef n)
		{
			DefaultPre(n);
		}

		public override void Post(LocalFuncDef n)
		{
			DefaultPost(n);
		}

		public override void Pre(LocalFuncDecl n)
		{
			DefaultPre(n);
		}

		public override void Post(LocalFuncDecl n)
		{
			DefaultPost(n);
		}

		public override void Pre(LocalVarDef n)
		{
			DefaultPre(n);
		}

		public override void Post(LocalVarDef n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprIntegerT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprIntegerT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprCharacterT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprCharacterT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprBinOpBase n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprBinOpBase n)
		{
			DefaultPost(n);
		}


		public override void Pre(ExprPlus n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprPlus n)
		{
			DefaultPost(n);
		}
		public override void Pre(ExprMinus n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprMinus n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprLValIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprFuncCall n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprFuncCall n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprLValIndexed n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprLValIndexed n)
		{
			DefaultPost(n);
		}

		public override void Pre(ExprLValStringT n)
		{
			DefaultPre(n);
		}

		public override void Post(ExprLValStringT n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondAnd n)
		{
			DefaultPre(n);
		}

		public override void Post(CondAnd n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondOr n)
		{
			DefaultPre(n);
		}

		public override void Post(CondOr n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondNot n)
		{
			DefaultPre(n);
		}

		public override void Post(CondNot n)
		{
			DefaultPost(n);
		}

		public override void Pre(CondRelOpBase n)
		{
			DefaultPre(n);
		}

		public override void Post(CondRelOpBase n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtAssign n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtAssign n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtBlock n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtBlock n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtFuncCall n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtFuncCall n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtIfThen n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtIfThen n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtIfThenElse n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtIfThenElse n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtWhileDo n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtWhileDo n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtNoOpT n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtNoOpT n)
		{
			DefaultPost(n);
		}

		public override void Pre(StmtReturn n)
		{
			DefaultPre(n);
		}

		public override void Post(StmtReturn n)
		{
			DefaultPost(n);
		}

		public override void Pre(HPar n)
		{
			DefaultPre(n);
		}

		public override void Post(HPar n)
		{
			DefaultPost(n);
		}

		public override void Post(ParIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Pre(ParIdentifierT n)
		{
			DefaultPre(n);
		}

		public override void Pre(VarIdentifierT n)
		{
			DefaultPre(n);
		}

		public override void Post(VarIdentifierT n)
		{
			DefaultPost(n);
		}

		public override void Pre(HTypeReturn n)
		{
			DefaultPre(n);
		}

		public override void Post(HTypeReturn n)
		{
			DefaultPost(n);
		}
	}
}
