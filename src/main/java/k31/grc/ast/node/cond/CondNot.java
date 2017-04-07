package k31.grc.ast.node.cond;

import k31.grc.ast.visitor.Visitor;

public class CondNot extends CondBase {

	private CondBase cond;

	public CondBase getCond() {
		return cond;
	}

	public void setCond(CondBase cond) {
		this.cond = cond;
	}

	public CondNot(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
