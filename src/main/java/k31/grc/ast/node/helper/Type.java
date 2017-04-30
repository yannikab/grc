package k31.grc.ast.node.helper;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class Type extends NodeBase {

	public Type() {
		super("type");
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
