package k31.grc.ast.node.aux;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class Ref extends NodeBase {

	public Ref() {
		super("ref");
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
