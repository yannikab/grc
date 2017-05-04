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

		protected NodeBase Parent { get { return parent; } }

		protected IReadOnlyList<NodeBase> Children { get { return children; } }

		public abstract string Text { get; }

		public abstract int Line { get; }

		public abstract int Pos { get; }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", Line, Pos); }
		}

		public NodeBase()
		{
			this.children = new List<NodeBase>();
		}

		public void AddChild(NodeBase c)
		{
			c.parent = this;

			children.Add(c);
		}

		protected virtual void ProcessChildren()
		{
		}

		public abstract void Accept(IVisitor v);

		public override string ToString()
		{
			return Text;
		}
	}
}
