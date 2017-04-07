package k31.grc.ast.node.expr;

import k31.grc.ast.visitor.Visitor;

public class LValueIndexed extends LValueBase {

	private LValueBase lval;
	private ExprBase expr;

	public LValueBase getLval() {
		return lval;
	}

	public ExprBase getExpr() {
		return expr;
	}

	public void setLval(LValueBase lval) {
		this.lval = lval;
	}

	public void setExpr(ExprBase expr) {
		this.expr = expr;
	}

	public LValueIndexed(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
