package k31.grc.ast.node.expr;

import k31.grc.ast.visitor.Visitor;

public abstract class ExprBinOpBase extends ExprBase {

	private ExprBase left;
	private ExprBase right;

	public ExprBase getLeft() {
		return left;
	}

	public ExprBase getRight() {
		return right;
	}

	public void setLeft(ExprBase left) {
		this.left = left;
	}

	public void setRight(ExprBase right) {
		this.right = right;
	}

	public ExprBinOpBase(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
