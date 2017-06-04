package k31.grc.ast.node.func;

import java.util.LinkedList;
import java.util.List;

import k31.grc.ast.node.Parameter;
import k31.grc.ast.node.type.TypeReturnBase;
import k31.grc.ast.visitor.Visitor;

public class LocalFuncDecl extends LocalBase {

	private String id;
	private TypeReturnBase returnType;
	private List<Parameter> params;

	public String getId() {
		return id;
	}

	public TypeReturnBase getReturnType() {
		return returnType;
	}

	public List<Parameter> getParams() {
		return params;
	}

	public void setId(String id) {

		this.id = id;
	}

	public void setReturnType(TypeReturnBase returnType) {

		this.returnType = returnType;
	}

	public void setParams(List<Parameter> params) {
		this.params = params;
	}

	public LocalFuncDecl(String string) {
		super(string);

		setId(string);

		params = new LinkedList<Parameter>();
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}

	@Override
	public String toString() {

		String s = super.toString();

		// s += "\n: " + returnType.toString();

		return s;
	}
}
