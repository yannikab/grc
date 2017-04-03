package k31.grc.graphviz;

import java.util.Stack;

import k31.grc.cst.analysis.DepthFirstAdapter;
import k31.grc.cst.node.Node;
import k31.grc.cst.node.Token;

public class GraphVizTraversal extends DepthFirstAdapter {

	private static int nodeNumber = 0;

	private Stack<GVNode> stack;

	public GraphVizTraversal(GVNode root) {

		stack = new Stack<GVNode>();

		stack.push(root);
	}

	@Override
	public void defaultIn(Node node) {
		// TODO Auto-generated method stub
		// super.defaultIn(node);

		addNode(node, node.getClass().getSimpleName());

		// System.out.printf("%02d: I ", level);
		// System.out.println();
	}

	protected void addNode(Node node, String text) {

		GVNode n = new GVNode(nodeNumber, text);
		stack.peek().addChild(n);

		if (!(node instanceof Token))
			stack.push(n);

		nodeNumber++;
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
