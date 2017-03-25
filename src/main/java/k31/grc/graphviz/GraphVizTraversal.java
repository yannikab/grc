package k31.grc.graphviz;

import java.util.Stack;

import k31.grc.analysis.DepthFirstAdapter;
import k31.grc.node.Node;

public class GraphVizTraversal extends DepthFirstAdapter {

	private static int nodeNumber = 0;

	Stack<GVNode> stack;

	public GraphVizTraversal(GVNode root) {

		stack = new Stack<GVNode>();

		stack.push(root);
	}

	@Override
	public void defaultIn(Node node) {
		// TODO Auto-generated method stub
		// super.defaultIn(node);

		GVNode n = new GVNode(nodeNumber, node.getClass().getSimpleName());
		stack.peek().addChild(n);
		stack.push(n);

		nodeNumber++;

		// System.out.printf("%02d: I ", level);
		// System.out.println();
	}

	@Override
	public void defaultOut(Node node) {
		// TODO Auto-generated method stub
		// super.defaultIn(node);

		stack.pop();

		// System.out.printf("%02d: O ", level);
		// System.out.println(node.getClass().getSimpleName());
	}
}
