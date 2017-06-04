package k31.grc.ast.node.stmt;

import java.util.LinkedList;
import java.util.List;

import k31.grc.ast.visitor.Visitor;

public class StmtBlock extends StmtBase {

	private List<StmtBase> stmts;

	public List<StmtBase> getStmts() {
		return stmts;
	}

	public StmtBlock(String text) {
		super(text);

		this.stmts = new LinkedList<StmtBase>();
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
