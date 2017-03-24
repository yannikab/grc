package k31.grc;

import k31.grc.analysis.DepthFirstAdapter;
import k31.grc.node.Node;

public class SimpleTraversal extends DepthFirstAdapter {

	private static int level = 0;

	@Override
	public void defaultIn(Node node) {
		// TODO Auto-generated method stub
		// super.defaultIn(node);

		System.out.printf("%02d: I ", level);
		System.out.println(node.getClass().getSimpleName());
		level++;
	}

	@Override
	public void defaultOut(Node node) {
		// TODO Auto-generated method stub
		// super.defaultIn(node);

		level--;
		System.out.printf("%02d: O ", level);
		System.out.println(node.getClass().getSimpleName());
	}
}
