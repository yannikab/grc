package k31.grc.ast.node.cond;

import k31.grc.ast.visitor.Visitor;

public class CondAnd extends CondBase {

	private CondBase left;
	private CondBase right;

	public CondBase getLeft() {
		return left;
	}

	public CondBase getRight() {
		return right;
	}

	public void setLeft(CondBase left) {
		this.left = left;
	}

	public void setRight(CondBase right) {
		this.right = right;
	}

	public CondAnd(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
