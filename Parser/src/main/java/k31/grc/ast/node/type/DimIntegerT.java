package k31.grc.ast.node.type;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.visitor.Visitor;

public class DimIntegerT extends NodeBase {

	private Integer dim;

	public Integer getDim() {
		return dim;
	}

	public DimIntegerT(String text) {
		super(text);

		this.dim = Integer.parseInt(text.replace("[", "").replace("]", ""));
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
