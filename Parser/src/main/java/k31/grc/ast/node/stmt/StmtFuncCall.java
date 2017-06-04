package k31.grc.ast.node.stmt;

import java.util.LinkedList;
import java.util.List;

import k31.grc.ast.node.expr.ExprBase;
import k31.grc.ast.visitor.Visitor;

public class StmtFuncCall extends StmtBase {

	private String id;
	private List<ExprBase> args;

	public String getId() {
		return id;
	}

	public List<ExprBase> getArgs() {
		return args;
	}

	public void setId(String id) {
		this.id = id;
	}

	public StmtFuncCall() {
		super("()");

		this.args = new LinkedList<ExprBase>();
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}

	@Override
	public String toString() {

		return id;
	}
}
