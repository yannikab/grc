using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grc.Visitors.Cst
{
	public class GVNode
	{
		private GVNode parent;

		private List<GVNode> children;

		private int id;

		private string data;

		public GVNode(int id, string data)
			: this(id)
		{
			this.data = data;
		}

		public GVNode(int id)
		{
			this.id = id;

			this.children = new List<GVNode>();
		}

		public void addChild(GVNode child)
		{
			child.parent = this;

			this.children.Add(child);
		}

		public void print()
		{
			Console.WriteLine(this.id);
			Console.WriteLine(this.data);

			foreach (GVNode c in children)
				c.print();
		}

		public void printRelations()
		{
			foreach (GVNode c in children)
			{
				Console.WriteLine(this.id + " -> " + c.id);

				c.printRelations();
			}
		}

		public void printGraphViz()
		{
			// pre
			if (this.parent != null)
			{
				Console.WriteLine("\t" + this.gvName() + " ;");

				Console.WriteLine("\t" + this.gvName() + " [label=\"" + gvData() + "\"] ;");
			}

			// in
			foreach (GVNode c in children)
			{
				if (this.parent != null)
					Console.WriteLine("\t" + this.gvName() + " -- " + c.gvName() + " ;");

				c.printGraphViz();
			}

			// post
		}

		public string gvName()
		{
			return string.Format("n{0:D4}", this.id);
		}

		public string gvData()
		{
			return data.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("[", "\\[").Replace("]", "\\]");
		}
	}
}
