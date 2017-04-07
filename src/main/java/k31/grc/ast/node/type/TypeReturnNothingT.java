package k31.grc.ast.node.type;

import k31.grc.ast.visitor.Visitor;

public class TypeReturnNothingT extends TypeReturnBase {

	public TypeReturnNothingT(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
