using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Visitors.Cst
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAAdditionExpression(AAdditionExpression node)
		{
			helper.Pre();
		}

		public override void outAAdditionExpression(AAdditionExpression node)
		{
			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new ExprAdd(left, right, node.getOperPlus().getText()));
		}

		public override void inASubtractionExpression(ASubtractionExpression node)
		{
			helper.Pre();
		}

		public override void outASubtractionExpression(ASubtractionExpression node)
		{
			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new ExprSub(left, right, node.getOperMinus().getText()));
		}

		public override void inAMultiplyTerm(AMultiplyTerm node)
		{
			helper.Pre();
		}

		public override void outAMultiplyTerm(AMultiplyTerm node)
		{
			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new ExprMul(left, right, node.getOperMul().getText()));
		}

		public override void inADivTerm(ADivTerm node)
		{
			helper.Pre();
		}

		public override void outADivTerm(ADivTerm node)
		{
			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new ExprDiv(left, right, node.getOperDiv().getText()));
		}

		public override void inAModTerm(AModTerm node)
		{
			helper.Pre();
		}

		public override void outAModTerm(AModTerm node)
		{
			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new ExprMod(left, right, node.getOperMod().getText()));
		}

		public override void inAIntegerFactor(AIntegerFactor node)
		{
			helper.Pre();
		}

		public override void outAIntegerFactor(AIntegerFactor node)
		{
			Token t = node.getInteger();

			helper.Post(new ExprIntegerT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inACharacterFactor(ACharacterFactor node)
		{
			helper.Pre();
		}

		public override void outACharacterFactor(ACharacterFactor node)
		{
			Token t = node.getCharacter();

			helper.Post(new ExprCharacterT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAPlusFactor(APlusFactor node)
		{
			helper.Pre();
		}

		public override void outAPlusFactor(APlusFactor node)
		{
			Token t = node.getOperPlus();

			ExprBase expr = (ExprBase)helper[0];

			helper.Post(new ExprPlus(expr, t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAMinusFactor(AMinusFactor node)
		{
			helper.Pre();
		}

		public override void outAMinusFactor(AMinusFactor node)
		{
			Token t = node.getOperMinus();

			ExprBase expr = (ExprBase)helper[0];

			helper.Post(new ExprMinus(expr, t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAIndexedLValue(AIndexedLValue node)
		{
			helper.Pre();
		}

		public override void outAIndexedLValue(AIndexedLValue node)
		{
			Token lbrack = node.getSepLbrack();
			Token rbrack = node.getSepRbrack();

			ExprLValBase lval = (ExprLValBase)helper[0];
			ExprBase expr = (ExprBase)helper[1];

			helper.Post(new ExprLValIndexed(lval, expr, lbrack.getText(), rbrack.getText()));
		}

		public override void inAStringLValue(AStringLValue node)
		{
			helper.Pre();
		}

		public override void outAStringLValue(AStringLValue node)
		{
			Token t = node.getString();

			helper.Post(new ExprLValStringT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAIdentifierLValue(AIdentifierLValue node)
		{
			helper.Pre();
		}

		public override void outAIdentifierLValue(AIdentifierLValue node)
		{
			Token id = node.getIdentifier();

			helper.Post(new ExprLValIdentifierT(id.getText(), id.getLine(), id.getPos()));
		}

		public override void inAFunctionCall(AFunctionCall node)
		{
			helper.Pre();
		}

		public override void outAFunctionCall(AFunctionCall node)
		{
			Token id = node.getIdentifier();
			Token lpar = node.getSepLpar();
			Token rpar = node.getSepRpar();

			List<ExprBase> args = new List<ExprBase>();

			for (int i = 0; i < helper.Count; i++)
				args.Add((ExprBase)helper[i]);

			ExprFuncCall exprFuncCall = new ExprFuncCall(args, id.getText(), lpar.getText(), rpar.getText(), id.getLine(), id.getPos());

			helper.Post(exprFuncCall);
		}
	}
}
