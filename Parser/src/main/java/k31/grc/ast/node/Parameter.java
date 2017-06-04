package k31.grc.ast.node;

import java.util.List;

import k31.grc.ast.node.type.TypeDataBase;

public class Parameter {

	private boolean ref;
	private String id;
	private TypeDataBase type;
	private boolean nodim;
	private List<Integer> dims;

	public Parameter(String id, boolean ref, TypeDataBase type, boolean nodim, List<Integer> dims) {
		this.id = id;
		this.ref = ref;
		this.type = type;
		this.nodim = nodim;
		this.dims = dims;
	}

	@Override
	public String toString() {

		String t = ref ? "ref " : "";

		t += id + "\n" + type.getText();

		if (nodim)
			t += "[]";

		for (int i : dims)
			t += "[" + i + "]";

		return t;
	}
}
