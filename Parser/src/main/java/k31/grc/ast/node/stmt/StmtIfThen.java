package k31.grc.ast.node.stmt;

import k31.grc.ast.node.cond.CondBase;
import k31.grc.ast.visitor.Visitor;

public class StmtIfThen extends StmtBase {

	private CondBase cond;
	private StmtBase stmt;

	public CondBase getCond() {
		return cond;
	}

	public void setCond(CondBase cond) {
		this.cond = cond;
	}

	public StmtBase getStmt() {
		return stmt;
	}

	public void setStmt(StmtBase stmt) {
		this.stmt = stmt;
	}

	public StmtIfThen(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
