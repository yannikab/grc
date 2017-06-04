package k31.grc.ast.node;

import java.util.List;

import k31.grc.ast.node.type.TypeDataBase;

public class Variable {

	private String id;
	private TypeDataBase type;
	private List<Integer> dims;

	public Variable(String id, TypeDataBase type, List<Integer> dims) {
		this.id = id;
		this.type = type;
		this.dims = dims;
	}

	@Override
	public String toString() {

		String t = id + "\n" + type.getText();

		for (int i : dims)
			t += "[" + i + "]";

		return t;
	}
}
