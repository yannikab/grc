using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Visitors.Ast;
using Grc.Nodes.Helper;

namespace Grc.Nodes
{
	public abstract partial class NodeBase
	{
		public abstract string Text { get; }

		public abstract int Line { get; }

		public abstract int Pos { get; }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", Line, Pos); }
		}

		public NodeBase Parent { get; set; }

		protected virtual int Indent
		{
			get { return Parent == null || Parent is Root ? 0 : Parent.Indent + 1; }
		}

		protected string Tabs
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				for (int i = 0; i < Indent; i++)
					sb.Append("\t");

				return sb.ToString();
			}
		}

		public abstract void Accept(IVisitor v);

		public override string ToString()
		{
			return Text;
		}
	}
}
