package k31.grc.ast.node.func;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class VarIdentifierT extends NodeBase {

	public VarIdentifierT(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
