package k31.grc.ast.node.stmt;

import k31.grc.ast.node.expr.ExprBase;
import k31.grc.ast.node.expr.LValueBase;
import k31.grc.ast.visitor.Visitor;

public class StmtAssign extends StmtBase {

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

	public StmtAssign(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
