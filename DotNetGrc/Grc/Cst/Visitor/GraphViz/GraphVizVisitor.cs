using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.GraphViz
{
	public class GraphVizVisitor : DepthFirstAdapter
	{
		private static int nodeNumber = 0;

		private Stack<GVNode> stack;

		public GraphVizVisitor(GVNode root)
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

		protected void addNode(Node node, string text)
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
