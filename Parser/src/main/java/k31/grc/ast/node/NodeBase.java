package k31.grc.ast.node;

import java.util.LinkedList;
import java.util.List;

import k31.grc.ast.visitor.Visitor;
import k31.grc.cst.visitor.GVNode;

public abstract class NodeBase {

	private NodeBase parent;

	private List<NodeBase> children;

	private String text;

	public NodeBase getParent() {

		return parent;
	}

	public List<NodeBase> getChildren() {

		return children;
	}

	public String getText() {

		return text;
	}

	public NodeBase(String text) {

		this.text = text;

		this.children = new LinkedList<NodeBase>();
	}

	public void addChild(NodeBase c) {

		c.parent = this;

		children.add(c);
	}

	public abstract void accept(Visitor v);

	@Override
	public String toString() {

		return text;
	}
}
