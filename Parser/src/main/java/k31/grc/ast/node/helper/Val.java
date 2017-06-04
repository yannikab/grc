package k31.grc.ast.node.helper;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class Val extends NodeBase {

	public Val() {
		super("val");
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
