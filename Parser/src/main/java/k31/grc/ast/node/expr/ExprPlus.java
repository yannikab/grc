package k31.grc.ast.node.expr;

import k31.grc.ast.visitor.Visitor;

public class ExprPlus extends ExprBase {

	private ExprBase expr;

	public ExprBase getExpr() {
		return expr;
	}

	public void setExpr(ExprBase expr) {
		this.expr = expr;
	}

	public ExprPlus(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
