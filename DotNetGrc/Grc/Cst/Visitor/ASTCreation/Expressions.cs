using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAAdditionExpression(AAdditionExpression node)
		{
			defaultIn(node);

			PushNode(new ExprAdd(node.getOperPlus().getText()));
		}

		public override void outAAdditionExpression(AAdditionExpression node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inASubtractionExpression(ASubtractionExpression node)
		{
			defaultIn(node);

			PushNode(new ExprSub(node.getOperMinus().getText()));
		}

		public override void outASubtractionExpression(ASubtractionExpression node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAMultiplyTerm(AMultiplyTerm node)
		{
			defaultIn(node);

			PushNode(new ExprMul(node.getOperMul().getText()));
		}

		public override void outAMultiplyTerm(AMultiplyTerm node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inADivTerm(ADivTerm node)
		{
			defaultIn(node);

			PushNode(new ExprDiv(node.getOperDiv().getText()));
		}

		public override void outADivTerm(ADivTerm node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAModTerm(AModTerm node)
		{
			defaultIn(node);

			PushNode(new ExprMod(node.getOperMod().getText()));
		}

		public override void outAModTerm(AModTerm node)
		{
			defaultOut(node);

			PopNode();
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

			Token t = node.getOperPlus();

			PushNode(new ExprPlus(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outAPlusFactor(APlusFactor node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAMinusFactor(AMinusFactor node)
		{
			defaultIn(node);

			Token t = node.getOperMinus();

			PushNode(new ExprPlus(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outAMinusFactor(AMinusFactor node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIndexedLValue(AIndexedLValue node)
		{
			defaultIn(node);

			Token lbrack = node.getSepLbrack();
			Token rbrack = node.getSepRbrack();

			PushNode(new ExprLValIndexed(lbrack.getText(), rbrack.getText()));
		}

		public override void outAIndexedLValue(AIndexedLValue node)
		{
			defaultOut(node);

			PopNode();
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

			Token id = node.getIdentifier();

			PushNode(new ExprLValIdentifierT(id.getText(), id.getLine(), id.getPos()));
		}

		public override void outAIdentifierLValue(AIdentifierLValue node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFunctionCall(AFunctionCall node)
		{
			defaultIn(node);

			Token id = node.getIdentifier();
			Token lpar = node.getSepLpar();
			Token rpar = node.getSepRpar();

			PushNode(new ExprFuncCall(id.getText(), lpar.getText(), rpar.getText(), id.getLine(), id.getPos()));
		}

		public override void outAFunctionCall(AFunctionCall node)
		{
			defaultOut(node);

			PopNode();
		}
	}
}
