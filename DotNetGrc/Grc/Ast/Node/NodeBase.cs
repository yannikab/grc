using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node
{
	public abstract partial class NodeBase
	{
		private string text;

		public string Text { get { return text ?? (text = GetText()); } }

		public abstract int Line { get; }

		public abstract int Pos { get; }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", Line, Pos); }
		}

		public NodeBase Parent { get; set; }

		protected virtual int Indent
		{
			get { return Parent != null ? Parent.Indent + 1 : 0; }
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

		protected abstract string GetText();

		public override string ToString()
		{
			return Text;
		}
	}
}
