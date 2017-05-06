﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		private Stack<NodeBase> stack;

		public ASTCreationVisitor(NodeBase root)
		{
			stack = new Stack<NodeBase>();

			stack.Push(root);
		}

		private void PushNode(NodeBase node)
		{
			stack.Peek().AddChild(node);

			stack.Push(node);
		}

		private void PopNode()
		{
			stack.Pop();
		}

		public override void inStart(Start node)
		{
			defaultIn(node);
		}

		public override void outStart(Start node)
		{
			defaultOut(node);
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