package k31.grc.ast.node.helper;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class Root extends NodeBase {

	public Root() {
		super("root");
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
