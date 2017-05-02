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
		private void outExprBinOp()
		{
			ExprBinOpBase n = (ExprBinOpBase)GetNode();

			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is ExprBase && n.Children[1] is ExprBase))
				return;

			n.Left = (ExprBase)n.Children[0];
			n.Right = (ExprBase)n.Children[1];
		}

		public override void inAAdditionExpression(AAdditionExpression node)
		{
			defaultIn(node);

			PushNode(new ExprAdd(node.getOperPlus().getText()));
		}

		public override void outAAdditionExpression(AAdditionExpression node)
		{
			defaultOut(node);

			outExprBinOp();
		}

		public override void inASubtractionExpression(ASubtractionExpression node)
		{
			defaultIn(node);

			PushNode(new ExprSub(node.getOperMinus().getText()));
		}

		public override void outASubtractionExpression(ASubtractionExpression node)
		{
			defaultOut(node);

			outExprBinOp();
		}

		public override void inAMultiplyTerm(AMultiplyTerm node)
		{
			defaultIn(node);

			PushNode(new ExprMul(node.getOperMul().getText()));
		}

		public override void outAMultiplyTerm(AMultiplyTerm node)
		{
			defaultOut(node);

			outExprBinOp();
		}

		public override void inADivTerm(ADivTerm node)
		{
			defaultIn(node);

			PushNode(new ExprDiv(node.getOperDiv().getText()));
		}

		public override void outADivTerm(ADivTerm node)
		{
			defaultOut(node);

			outExprBinOp();
		}

		public override void inAModTerm(AModTerm node)
		{
			defaultIn(node);

			PushNode(new ExprMod(node.getOperMod().getText()));
		}

		public override void outAModTerm(AModTerm node)
		{
			defaultOut(node);

			outExprBinOp();
		}

		public override void inAIntegerFactor(AIntegerFactor node)
		{
			defaultIn(node);

			Token t = node.getInteger();

			PushNode(new ExprIntegerT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outAIntegerFactor(AIntegerFactor node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inACharacterFactor(ACharacterFactor node)
		{
			defaultIn(node);

			Token t = node.getCharacter();

			PushNode(new ExprCharacterT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outACharacterFactor(ACharacterFactor node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAPlusFactor(APlusFactor node)
		{
			defaultIn(node);

			PushNode(new ExprPlus(node.getOperPlus().getText()));
		}

		public override void outAPlusFactor(APlusFactor node)
		{
			defaultOut(node);

			ExprPlus n = (ExprPlus)GetNode();
			PopNode();

			if (n.Children.Count != 1)
				return;

			if (!(n.Children[0] is ExprBase))
				return;

			n.Expr = (ExprBase)n.Children[0];
		}

		public override void inAMinusFactor(AMinusFactor node)
		{
			defaultIn(node);

			PushNode(new ExprMinus(node.getOperMinus().getText()));
		}

		public override void outAMinusFactor(AMinusFactor node)
		{
			defaultOut(node);

			ExprMinus n = (ExprMinus)GetNode();
			PopNode();

			if (n.Children.Count != 1)
				return;

			if (!(n.Children[0] is ExprBase))
				return;

			n.Expr = (ExprBase)n.Children[0];
		}

		public override void inAIndexedLValue(AIndexedLValue node)
		{
			defaultIn(node);

			PushNode(new NodeBase());
		}

		public override void outAIndexedLValue(AIndexedLValue node)
		{
			defaultOut(node);

			NodeBase nb = PopNode();

			if (nb.Children.Count != 2)
				return;

			ExprLValBase lval = nb.Children[0] as ExprLValBase;
			ExprBase expr = nb.Children[1] as ExprBase;

			if (lval == null || expr == null)
				return;

			Token t1 = node.getSepLbrack();
			Token t2 = node.getSepRbrack();

			string text = string.Format("{0}{1}", t1.getText(), t2.getText());

			nb.ReplaceWith(new ExprLValIndexed(text, lval, expr));
		}

		public override void inAStringLValue(AStringLValue node)
		{
			defaultIn(node);

			Token t = node.getString();

			PushNode(new ExprLValStringT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outAStringLValue(AStringLValue node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIdentifierLValue(AIdentifierLValue node)
		{
			defaultIn(node);

			PushNode(new NodeBase());
		}

		public override void outAIdentifierLValue(AIdentifierLValue node)
		{
			defaultOut(node);

			NodeBase nb = PopNode();

			Token t = node.getIdentifier();

			nb.ReplaceWith(new ExprLValIdentifierT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAFunctionCall(AFunctionCall node)
		{
			defaultIn(node);

			PushNode(new NodeBase());
		}

		public override void outAFunctionCall(AFunctionCall node)
		{
			defaultOut(node);

			NodeBase nb = PopNode();

			IList<ExprBase> args = new List<ExprBase>();

			for (int i = 0; i < nb.Children.Count; i++)
			{
				ExprBase expr = nb.Children[i] as ExprBase;

				if (expr == null)
					return;

				args.Add(expr);
			}

			Token id = node.getIdentifier();
			Token l = node.getSepLpar();
			Token r = node.getSepRpar();

			String text = string.Format("{0}{1}{2}", id.getText(), l.getText(), r.getText());

			nb.ReplaceWith(new ExprFuncCall(text, args, id.getLine(), id.getPos()));
		}
	}
}
