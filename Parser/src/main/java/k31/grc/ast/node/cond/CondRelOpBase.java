package k31.grc.ast.node.cond;

import k31.grc.ast.node.expr.ExprBase;
import k31.grc.ast.visitor.Visitor;

public abstract class CondRelOpBase extends CondBase {

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

	public CondRelOpBase(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
