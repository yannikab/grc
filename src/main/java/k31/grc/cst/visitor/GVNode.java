package k31.grc.cst.visitor;

import java.util.LinkedList;
import java.util.List;

public class GVNode {

	@SuppressWarnings("unused")
	private GVNode parent;

	private List<GVNode> children;

	@SuppressWarnings("unused")
	private int id;

	private String data;

	public GVNode(int id, String data) {

		this(id);

		this.data = data;
	}

	public GVNode(int id) {

		this.id = id;

		this.children = new LinkedList<GVNode>();
	}

	public void addChild(GVNode child) {

		child.parent = this;
		this.children.add(child);
	}

	public void print() {

		System.out.println(this.id);
		System.out.println(this.data);

		for (GVNode c : children) {
			c.print();
		}
	}

	public void printRelations() {

		for (GVNode c : children) {

			System.out.println(this.id + " -> " + c.id);

			c.printRelations();
		}

	}

	public void printGraphViz() {

		// pre
		if (this.parent != null) {

			System.out.println("\t" + this.gvName() + " ;");

			System.out.println("\t" + this.gvName() + " [label=\"" + gvData() + "\"] ;");
		}

		// in
		for (GVNode c : children) {

			if (this.parent != null)
				System.out.println("\t" + this.gvName() + " -- " + c.gvName() + " ;");

			c.printGraphViz();
		}

		// post

	}

	public String gvName() {

		return String.format("n%1$04d", this.id);
	}

	public String gvData() {

		return data
				.replace("\\", "\\\\")
				.replace("\"", "\\\"")
				.replace("[", "\\[")
				.replace("]", "\\]");
	}
}
