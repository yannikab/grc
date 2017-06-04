package k31.grc.ast.node.stmt;

import k31.grc.ast.visitor.Visitor;

public class StmtNoOpT extends StmtBase {

	public StmtNoOpT(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
