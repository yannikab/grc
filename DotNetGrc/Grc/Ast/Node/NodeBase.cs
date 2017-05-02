using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node
{
	public class NodeBase
	{
		private NodeBase parent;
		private List<NodeBase> children;

		private String text;

		public NodeBase Parent { get { return parent; } }
		public IReadOnlyList<NodeBase> Children { get { return children; } }

		public string Text { get { return text; } }

		public NodeBase()
		{
			this.children = new List<NodeBase>();
		}

		public NodeBase(string text)
			: this()
		{
			this.text = text;
		}

		public void AddChild(NodeBase c)
		{
			c.parent = this;

			children.Add(c);
		}

		public void ReplaceWith(NodeBase node)
		{
			if (parent != null)
			{
				int i = parent.children.IndexOf(this);
				parent.children.RemoveAt(i);
				parent.children.Insert(i, node);
			}

			node.parent = this.parent;
			this.parent = null;

			foreach (NodeBase c in this.children)
				node.AddChild(c);

			children.Clear();
		}

		public virtual void Accept(IVisitor v)
		{
		}

		public override string ToString()
		{
			return text;
		}
	}
}
