using System.Collections.Generic;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor
{
	public class GraphVizTraversal : DepthFirstAdapter
	{
		private static int nodeNumber = 0;

		private Stack<GVNode> stack;

		public GraphVizTraversal(GVNode root)
		{
			stack = new Stack<GVNode>();

			stack.Push(root);
		}

		public override void defaultIn(Node node)
		{
			// base.defaultOut(node);

			addNode(node, node.GetType().Name);

			// System.out.printf("%02d: I ", level);
			// System.out.println();
		}

		protected internal virtual void addNode(Node node, string text)
		{
			GVNode n = new GVNode(nodeNumber, text);
			stack.Peek().addChild(n);

			if (!(node is Token))
				stack.Push(n);

			nodeNumber++;
		}

		public override void defaultOut(Node node)
		{
			// base.defaultIn(node);

			stack.Pop();

			// System.out.printf("%02d: O ", level);
			// System.out.println(node.getClass().getSimpleName());
		}
	}
}
