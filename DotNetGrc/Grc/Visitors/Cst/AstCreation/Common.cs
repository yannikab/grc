using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Visitors.Cst
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		private BottomUpHelper<NodeBase> helper;
		private Root root;

		public ASTCreationVisitor(Root root)
		{
			this.helper = new BottomUpHelper<NodeBase>();
			this.root = root;
		}

		public override void inStart(Start node)
		{
			helper.Pre();
		}

		public override void outStart(Start node)
		{
			root.Program = (LocalFuncDef)helper[0];

			helper.Clear();
		}

		public override void defaultIn(Node node)
		{
			// Do nothing
		}

		public override void defaultOut(Node node)
		{
			// Do nothing
		}
	}
}
