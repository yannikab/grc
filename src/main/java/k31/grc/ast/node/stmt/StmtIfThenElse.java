package k31.grc.ast.node.stmt;

import k31.grc.ast.node.cond.CondBase;
import k31.grc.ast.visitor.Visitor;

public class StmtIfThenElse extends StmtBase {

	private CondBase cond;
	private StmtBase stmtThen;
	private StmtBase stmtElse;

	public CondBase getCond() {
		return cond;
	}

	public StmtBase getStmtThen() {
		return stmtThen;
	}

	public StmtBase getStmtElse() {
		return stmtElse;
	}

	public void setCond(CondBase cond) {
		this.cond = cond;
	}

	public void setStmtThen(StmtBase stmtThen) {
		this.stmtThen = stmtThen;
	}

	public void setStmtElse(StmtBase stmtElse) {
		this.stmtElse = stmtElse;
	}

	public StmtIfThenElse(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
