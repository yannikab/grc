package k31.grc.ast.node.expr;

import k31.grc.ast.visitor.Visitor;

public class LValueStringT extends LValueBase {

	public LValueStringT(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
