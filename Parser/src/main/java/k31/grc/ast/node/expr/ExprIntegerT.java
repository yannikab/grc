package k31.grc.ast.node.expr;

import k31.grc.ast.visitor.Visitor;

public class ExprIntegerT extends ExprBase {

	public ExprIntegerT(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
