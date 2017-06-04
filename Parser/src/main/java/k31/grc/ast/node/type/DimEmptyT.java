package k31.grc.ast.node.type;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class DimEmptyT extends NodeBase {

	public DimEmptyT(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
