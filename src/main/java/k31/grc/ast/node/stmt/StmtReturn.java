package k31.grc.ast.node.stmt;

import k31.grc.ast.node.expr.ExprBase;
import k31.grc.ast.visitor.Visitor;

public class StmtReturn extends StmtBase {

	private ExprBase expr;

	public ExprBase getExpr() {
		return expr;
	}

	public void setExpr(ExprBase expr) {
		this.expr = expr;
	}

	public StmtReturn(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
