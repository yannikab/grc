package k31.grc.ast.node.type;

import k31.grc.ast.visitor.Visitor;

public abstract class TypeDataBase extends TypeReturnBase {

	public TypeDataBase(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
