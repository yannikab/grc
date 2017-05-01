using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node
{
	public abstract class NodeBase
	{
		private NodeBase parent;

		private List<NodeBase> children;

		private String text;

		public NodeBase Parent
		{
			get { return parent; }
		}

		public IReadOnlyList<NodeBase> Children
		{
			get { return children; }
		}

		public String Text
		{
			get { return text; }
		}

		public NodeBase(String text)
		{
			this.text = text;

			this.children = new List<NodeBase>();
		}

		public void AddChild(NodeBase c)
		{
			c.parent = this;

			children.Add(c);
		}

		public abstract void Accept(IVisitor v);

		public override string ToString()
		{
			return text;
		}
	}
}
