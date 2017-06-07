using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;

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

		public override void DefaultPre(NodeBase n)
		{
			int i = nextId++;

			Console.WriteLine("\t" + GvName(i) + " ;");
			Console.WriteLine("\t" + GvName(i) + " [label=\"" + GvData(n.ToString()) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(stack.Peek()) + " -- " + GvName(i));

			stack.Push(i);
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
	}
}
