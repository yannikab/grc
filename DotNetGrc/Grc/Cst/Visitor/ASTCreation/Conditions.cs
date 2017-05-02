using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Node.Type;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAOrOpExpressionL(AOrOpExpressionL node)
		{
			defaultIn(node);

			PushNode(new CondOr(node.getOperOr().getText()));
		}

		public override void outAOrOpExpressionL(AOrOpExpressionL node)
		{
			defaultOut(node);

			CondOr n = (CondOr)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is CondBase && n.Children[1] is CondBase))
				return;

			n.Left = (CondBase)n.Children[0];
			n.Right = (CondBase)n.Children[1];
		}

		public override void inAAndOpTermL(AAndOpTermL node)
		{
			defaultIn(node);

			PushNode(new CondAnd(node.getOperAnd().getText()));
		}

		public override void outAAndOpTermL(AAndOpTermL node)
		{
			defaultOut(node);

			CondAnd n = (CondAnd)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is CondBase && n.Children[1] is CondBase))
				return;

			n.Left = (CondBase)n.Children[0];
			n.Right = (CondBase)n.Children[1];
		}

		public override void inANotOpFactorL(ANotOpFactorL node)
		{
			defaultIn(node);

			PushNode(new CondNot(node.getOperNot().getText()));
		}

		public override void outANotOpFactorL(ANotOpFactorL node)
		{
			defaultOut(node);

			CondNot n = (CondNot)GetNode();
			PopNode();

			if (n.Children.Count != 1)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			n.Cond = (CondBase)n.Children[0];
		}

		private void outCondRelOp()
		{
			CondRelOpBase n = (CondRelOpBase)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is ExprBase && n.Children[1] is ExprBase))
				return;

			n.Left = (ExprBase)n.Children[0];
			n.Right = (ExprBase)n.Children[1];
		}

		public override void inAEqualFactorL(AEqualFactorL node)
		{
			defaultIn(node);

			PushNode(new CondEq(node.getOperEq().getText()));
		}

		public override void outAEqualFactorL(AEqualFactorL node)
		{
			defaultOut(node);

			outCondRelOp();
		}

		public override void inANotEqualFactorL(ANotEqualFactorL node)
		{
			defaultIn(node);

			PushNode(new CondNe(node.getOperNe().getText()));
		}

		public override void outANotEqualFactorL(ANotEqualFactorL node)
		{
			defaultOut(node);

			outCondRelOp();
		}

		public override void inAGreaterThanFactorL(AGreaterThanFactorL node)
		{
			defaultIn(node);

			PushNode(new CondGt(node.getOperGt().getText()));
		}

		public override void outAGreaterThanFactorL(AGreaterThanFactorL node)
		{
			defaultOut(node);

			outCondRelOp();
		}

		public override void inALessThanFactorL(ALessThanFactorL node)
		{
			defaultIn(node);

			PushNode(new CondLt(node.getOperLt().getText()));
		}

		public override void outALessThanFactorL(ALessThanFactorL node)
		{
			defaultOut(node);

			outCondRelOp();
		}

		public override void inAGreaterEqualFactorL(AGreaterEqualFactorL node)
		{
			defaultIn(node);

			PushNode(new CondGe(node.getOperGe().getText()));
		}

		public override void outAGreaterEqualFactorL(AGreaterEqualFactorL node)
		{
			defaultOut(node);

			outCondRelOp();
		}

		public override void inALessEqualFactorL(ALessEqualFactorL node)
		{
			defaultIn(node);

			PushNode(new CondLe(node.getOperLe().getText()));
		}

		public override void outALessEqualFactorL(ALessEqualFactorL node)
		{
			defaultOut(node);

			outCondRelOp();
		}
	}
}
