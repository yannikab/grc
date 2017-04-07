package k31.grc.ast.node.expr;

import java.util.LinkedList;
import java.util.List;

import k31.grc.ast.visitor.Visitor;

public class ExprFuncCall extends ExprBase {

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

	public ExprFuncCall(String text) {
		super(text);

		this.id = text;
		
		this.args = new LinkedList<ExprBase>();
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
