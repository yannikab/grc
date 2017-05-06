using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Helper;

namespace Grc.Ast.Visitor.GraphViz
{
	class GraphVizNodeDataVisitor : DepthFirstVisitor
	{
		private IDictionary<NodeBase, int> id = new Dictionary<NodeBase, int>();

		private int nextId = 0;

		private Stack<NodeBase> stack = new Stack<NodeBase>();

		private void AddString(string s)
		{
			int i = nextId++;

			Console.WriteLine("\t" + GvName(i) + " ;");
			Console.WriteLine("\t" + GvName(i) + " [label=\"" + GvData(s) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(id[stack.Peek()]) + " -- " + GvName(i));
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

			Console.WriteLine("\t" + GvName(id[n]) + " ;");
			Console.WriteLine("\t" + GvName(id[n]) + " [label=\"" + GvData(n.ToString()) + "\"] ;");

			if (stack.Count > 0)
				Console.WriteLine("\t" + GvName(id[stack.Peek()]) + " -- " + GvName(id[n]));

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

		public override void Visit(HTypePar n)
		{
			AddString(n.Text);

		}

		public override void Visit(HTypeVar n)
		{
			AddString(n.Text);
		}
	}
}
