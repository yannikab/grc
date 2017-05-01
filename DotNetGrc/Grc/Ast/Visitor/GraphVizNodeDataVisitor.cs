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
	class GraphVizNodeDataVisitor : DepthFirstVisitor
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

		public override void DefaultPre(NodeBase n)
		{
			if (!id.ContainsKey(n))
				id[n] = nextId++;

			Console.WriteLine("\t" + GvName(id[n].Value) + " ;");
			Console.WriteLine("\t" + GvName(id[n].Value) + " [label=\"" + GvData(n.ToString()) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(id[stack.Peek()].Value) + " -- " + GvName(id[n].Value));

			stack.Push(n);
		}

		public override void DefaultPost(NodeBase n)
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

		public override void Visit(LocalFuncDef n)
		{
			DefaultPre(n);

			n.Header.Accept(this);

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			n.Block.Accept(this);

			DefaultPost(n);
		}

		public override void Visit(LocalVarDef n)
		{
			DefaultPre(n);

			foreach (var v in n.Vars)
				AddString(v.ToString());

			DefaultPost(n);
		}

		public override void Visit(LocalFuncDecl n)
		{
			DefaultPre(n);

			foreach (Parameter p in n.Params)
				AddString(p.ToString());

			n.ReturnType.Accept(this);

			DefaultPost(n);
		}
	}
}
