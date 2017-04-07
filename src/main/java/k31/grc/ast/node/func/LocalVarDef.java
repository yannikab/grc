package k31.grc.ast.node.func;

import k31.grc.ast.visitor.Visitor;

public class LocalVarDef extends LocalBase {

	public LocalVarDef(String text) {
		super(text);
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
