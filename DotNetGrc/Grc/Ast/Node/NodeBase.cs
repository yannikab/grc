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
		private string text;

		public string Text { get { return text ?? (text = GetText()); } }

		public abstract int Line { get; }

		public abstract int Pos { get; }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", Line, Pos); }
		}

		public NodeBase()
		{
		}

		public virtual void AddChild(NodeBase c)
		{
			c.parent = this;
		}

		public abstract void Accept(IVisitor v);

		protected abstract string GetText();

		public override string ToString()
		{
			return Text;
		}
	}
}
