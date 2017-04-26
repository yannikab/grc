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

namespace Grc.Cst.Visitor
{
	class ASTCreationVisitor : DepthFirstAdapter
	{
		private Stack<NodeBase> stack;

		public ASTCreationVisitor(NodeBase root)
		{
			stack = new Stack<NodeBase>();

			stack.Push(root);
		}

		protected internal virtual void PushNode(NodeBase node)
		{
			stack.Peek().AddChild(node);

			stack.Push(node);
		}

		protected internal virtual void PopNode()
		{
			stack.Pop();
		}

		protected internal virtual NodeBase GetNode()
		{
			return stack.Peek();
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

			PushNode(new ExprIntegerT(node.getInteger().getText()));
		}

		public override void outAIntegerFactor(AIntegerFactor node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inACharacterFactor(ACharacterFactor node)
		{
			defaultIn(node);

			PushNode(new ExprCharacterT(node.getCharacter().getText()));
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

			PushNode(new ExprLValIndexed(string.Format("{0}{1}", node.getSepLbrack().getText(), node.getSepRbrack().getText())));
		}

		public override void outAIndexedLValue(AIndexedLValue node)
		{
			defaultOut(node);

			ExprLValIndexed n = (ExprLValIndexed)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is ExprLValBase))
				return;

			if (!(n.Children[1] is ExprBase))
				return;

			n.Lval = (ExprLValBase)n.Children[0];
			n.Expr = (ExprBase)n.Children[1];
		}

		public override void inAStringLValue(AStringLValue node)
		{
			defaultIn(node);

			PushNode(new ExprLValStringT(node.getString().getText()));
		}

		public override void outAStringLValue(AStringLValue node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIdentifierLValue(AIdentifierLValue node)
		{
			defaultIn(node);

			PushNode(new ExprLValIdentifierT(node.getIdentifier().getText()));
		}

		public override void outAIdentifierLValue(AIdentifierLValue node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFunctionCall(AFunctionCall node)
		{
			defaultIn(node);

			PushNode(new ExprFuncCall(string.Format("{0}{1}{2}", node.getIdentifier().getText(), node.getSepLpar().getText(), node.getSepRpar().getText())));
		}

		public override void outAFunctionCall(AFunctionCall node)
		{
			defaultOut(node);

			ExprFuncCall n = (ExprFuncCall)GetNode();

			PopNode();

			for (int i = 0; i < n.Children.Count; i++)
				if (!(n.Children[i] is ExprBase))
					return;

			for (int i = 0; i < n.Children.Count; i++)
				n.AddArg((ExprBase)n.Children[i]);
		}

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

		public override void inASemicolonStmt(ASemicolonStmt node)
		{
			defaultIn(node);

			PushNode(new StmtNoOpT(node.getSepSemi().getText()));
		}

		public override void outASemicolonStmt(ASemicolonStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAAssignStmt(AAssignStmt node)
		{
			defaultIn(node);

			PushNode(new StmtAssign(node.getSepAssign().getText()));
		}

		public override void outAAssignStmt(AAssignStmt node)
		{
			defaultOut(node);

			StmtAssign n = (StmtAssign)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is ExprLValBase))
				return;

			if (!(n.Children[1] is ExprBase))
				return;

			n.Lval = (ExprLValBase)n.Children[0];
			n.Expr = (ExprBase)n.Children[1];
		}

		public override void inABlockStmt(ABlockStmt node)
		{
			defaultIn(node);

			PushNode(new StmtBlock(string.Format("{0} {1}", node.getSepLbrace().getText(), node.getSepRbrace().getText())));
		}

		public override void outABlockStmt(ABlockStmt node)
		{
			defaultOut(node);

			StmtBlock n = (StmtBlock)GetNode();
			PopNode();

			for (int i = 0; i < n.Children.Count; i++)
				if (!(n.Children[i] is StmtBase))
					return;

			for (int i = 0; i < n.Children.Count; i++)
				n.AddStmt((StmtBase)n.Children[i]);
		}

		public override void inAFunctionCallStmt(AFunctionCallStmt node)
		{
			defaultIn(node);

			PushNode(new StmtFuncCall());
		}

		public override void outAFunctionCallStmt(AFunctionCallStmt node)
		{
			defaultOut(node);

			StmtFuncCall n = (StmtFuncCall)GetNode();
			PopNode();

			if (n.Children.Count != 1 || !(n.Children[0] is ExprFuncCall))
				return;

			ExprFuncCall c = (ExprFuncCall)n.Children[0];

			n.Id = c.Id;

			for (int i = 0; i < c.Children.Count; i++)
				if (!(c.Children[i] is ExprBase))
					return;

			for (int i = 0; i < c.Children.Count; i++)
				n.AddArg((ExprBase)c.Children[i]);
		}

		public override void inAReturnStmt(AReturnStmt node)
		{
			defaultIn(node);

			PushNode(new StmtReturn(node.getKeyReturn().getText()));
		}

		public override void outAReturnStmt(AReturnStmt node)
		{
			defaultOut(node);

			StmtReturn n = (StmtReturn)GetNode();
			PopNode();

			if (n.Children.Count > 1)
				return;

			if (n.Children.Count == 1 && !(n.Children[0] is ExprBase))
				return;

			n.Expr = n.Children.Count == 1 ? (ExprBase)n.Children[0] : null;
		}

		public override void inAThenIfStmt(AThenIfStmt node)
		{
			defaultIn(node);

			PushNode(new StmtIfThen(string.Format("{0}-{1}", node.getKeyIf().getText(), node.getKeyThen().getText())));
		}

		public override void outAThenIfStmt(AThenIfStmt node)
		{
			defaultOut(node);

			StmtIfThen n = (StmtIfThen)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			if (!(n.Children[1] is StmtBase))
				return;

			n.Cond = (CondBase)n.Children[0];
			n.Stmt = (StmtBase)n.Children[1];
		}

		private void outStmtIfThenElse()
		{
			StmtIfThenElse n = (StmtIfThenElse)GetNode();
			PopNode();

			if (n.Children.Count != 3)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			if (!(n.Children[1] is StmtBase && n.Children[2] is StmtBase))
				return;

			n.Cond = (CondBase)n.Children[0];
			n.StmtThen = (StmtBase)n.Children[1];
			n.StmtElse = (StmtBase)n.Children[2];
		}

		public override void inAThenElseIfStmt(AThenElseIfStmt node)
		{
			defaultIn(node);

			PushNode(new StmtIfThenElse(string.Format("{0}-{1}-{2}", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText())));
		}

		public override void outAThenElseIfStmt(AThenElseIfStmt node)
		{
			defaultOut(node);

			outStmtIfThenElse();
		}

		public override void inAIfStmtElse(AIfStmtElse node)
		{
			defaultIn(node);

			PushNode(new StmtIfThenElse(string.Format("{0}-{1}-{2}", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText())));
		}

		public override void outAIfStmtElse(AIfStmtElse node)
		{
			defaultOut(node);

			outStmtIfThenElse();
		}

		private void outStmtWhileDo()
		{
			StmtWhileDo n = (StmtWhileDo)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			if (!(n.Children[1] is StmtBase))
				return;

			n.Cond = (CondBase)n.Children[0];
			n.Stmt = (StmtBase)n.Children[1];
		}

		public override void inAWhileStmt(AWhileStmt node)
		{
			defaultIn(node);

			PushNode(new StmtWhileDo(string.Format("{0}-{1}", node.getKeyWhile().getText(), node.getKeyDo().getText())));
		}

		public override void outAWhileStmt(AWhileStmt node)
		{
			defaultOut(node);

			outStmtWhileDo();
		}

		public override void inAWhileStmtElse(AWhileStmtElse node)
		{
			defaultIn(node);

			PushNode(new StmtWhileDo(string.Format("{0}-{1}", node.getKeyWhile().getText(), node.getKeyDo().getText())));
		}

		public override void outAWhileStmtElse(AWhileStmtElse node)
		{
			defaultOut(node);

			outStmtWhileDo();
		}

		public override void inACharDataType(ACharDataType node)
		{
			defaultIn(node);

			PushNode(new TypeDataCharT(node.getKeyChar().getText()));
		}

		public override void outACharDataType(ACharDataType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIntDataType(AIntDataType node)
		{
			defaultIn(node);

			PushNode(new TypeDataIntT(node.getKeyInt().getText()));
		}

		public override void outAIntDataType(AIntDataType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inADataReturnType(ADataReturnType node)
		{
			defaultIn(node);

			PushNode(new HType());
		}

		public override void outADataReturnType(ADataReturnType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inANothingReturnType(ANothingReturnType node)
		{
			defaultIn(node);

			PushNode(new HType());

			PushNode(new TypeReturnNothingT((node.getKeyNothing().getText())));
			PopNode();
		}

		public override void outANothingReturnType(ANothingReturnType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAArrayNoDim(AArrayNoDim node)
		{
			defaultIn(node);

			PushNode(new DimEmptyT(string.Format("{0}{1}", node.getSepLbrack().getText(), node.getSepRbrack().getText())));
		}

		public override void outAArrayNoDim(AArrayNoDim node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAArrayDim(AArrayDim node)
		{
			defaultIn(node);

			PushNode(new DimIntegerT(string.Format("{0}{1}{2}", node.getSepLbrack().getText(), node.getInteger().getText(), node.getSepRbrack().getText())));
		}

		public override void outAArrayDim(AArrayDim node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAType(AType node)
		{
			defaultIn(node);

			PushNode(new HType());
		}

		public override void outAType(AType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAVarDef(AVarDef node)
		{
			defaultIn(node);

			PushNode(new LocalVarDef(node.getKeyVar().getText()));

			PushNode(new VarIdentifierT(node.getIdentifier().getText()));
			PopNode();
		}

		public override void outAVarDef(AVarDef node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAVarMore(AVarMore node)
		{
			defaultIn(node);

			PushNode(new VarIdentifierT(node.getIdentifier().getText()));
		}

		public override void outAVarMore(AVarMore node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFparType(AFparType node)
		{
			defaultIn(node);

			PushNode(new HType());
		}

		public override void outAFparType(AFparType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFparDef(AFparDef node)
		{
			defaultIn(node);

			if (node.getKeyRef() != null)
				PushNode(new HRef());
			else
				PushNode(new HVal());

			PushNode(new FParIdentifierT(node.getIdentifier().getText()));
			PopNode();
		}

		public override void outAFparDef(AFparDef node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAParMore(AParMore node)
		{
			defaultIn(node);

			PushNode(new FParIdentifierT(node.getIdentifier().getText()));
		}

		public override void outAParMore(AParMore node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAHeader(AHeader node)
		{
			defaultIn(node);

			PushNode(new LocalFuncDecl(string.Format("{0}{1}{2}", node.getIdentifier().getText(), node.getSepLpar().getText(), node.getSepRpar().getText())));
		}

		public override void outAHeader(AHeader node)
		{
			defaultOut(node);

			LocalFuncDecl n = (LocalFuncDecl)GetNode();

			PopNode();

			processFuncDecl(n);
		}

		private void processFuncDecl(LocalFuncDecl n)
		{
			if (n.Children.Count < 1)
				return;

			for (int i = 0; i < n.Children.Count; i++)
			{
				NodeBase c = n.Children[i];

				if (c is HRef)
				{
					getParams(c, true);
				}
				else if (c is HVal)
				{
					getParams(c, false);
				}
				else if (c is HType)
				{
					getReturnType((HType)c);
				}
				else
				{
					return;
				}
			}
		}

		private void getParams(NodeBase n, bool @ref)
		{
			if (!(n.Parent is LocalFuncDecl))
				return;

			LocalFuncDecl d = (LocalFuncDecl)n.Parent;

			IList<string> @params = new List<string>();

			for (int i = 0; i < n.Children.Count; i++)
			{
				NodeBase p = n.Children[i];

				if (p is FParIdentifierT)
				{
					@params.Add(((FParIdentifierT)p).Text);
				}
				else if (p is HType)
				{
					addParams(d, @ref, @params, (HType)p);
				}
				else
				{
					return;
				}
			}
		}

		private void addParams(LocalFuncDecl d, bool @ref, IList<string> @params, HType t)
		{
			TypeDataBase type = null;

			bool dimEmpty = false;

			IList<int> dims = new List<int>();

			for (int i = 0; i < t.Children.Count; i++)
			{
				NodeBase c = t.Children[i];

				if (c is TypeDataBase)
				{
					type = (TypeDataBase)c;
				}
				else if (c is DimEmptyT)
				{
					if (dimEmpty)
						return;

					dimEmpty = true;
				}
				else if (c is DimIntegerT)
				{
					dims.Add(((DimIntegerT)c).Dim);
				}
				else
				{
					return;
				}
			}

			if (type == null)
				return;

			for (int i = 0; i < @params.Count; i++)
				d.AddParam(new Parameter(@params[i], @ref, type, dimEmpty, dims));
		}

		private void getReturnType(HType n)
		{
			if (!(n.Parent is LocalFuncDecl))
				return;

			LocalFuncDecl d = (LocalFuncDecl)n.Parent;

			if (n.Children.Count != 1)
				return;

			NodeBase t = n.Children[0];

			if (!(t is TypeReturnBase))
				return;

			d.ReturnType = (TypeReturnBase)t;
		}

		public override void inAFuncParams(AFuncParams node)
		{
			defaultIn(node);
		}

		public override void outAFuncParams(AFuncParams node)
		{
			defaultOut(node);
		}

		public override void inAFparDefMore(AFparDefMore node)
		{
			defaultIn(node);
		}

		public override void outAFparDefMore(AFparDefMore node)
		{
			defaultOut(node);
		}

		public override void inAFuncDecl(AFuncDecl node)
		{
			defaultIn(node);
		}

		public override void outAFuncDecl(AFuncDecl node)
		{
			defaultOut(node);
		}

		public override void inAFuncDef(AFuncDef node)
		{
			defaultIn(node);

			PushNode(new LocalFuncDef());
		}

		public override void outAFuncDef(AFuncDef node)
		{
			defaultOut(node);

			LocalFuncDef n = (LocalFuncDef)GetNode();

			PopNode();

			if (n.Children.Count < 2)
				return;

			if (!(n.Children[0] is LocalFuncDecl))
				return;

			for (int i = 1; i < n.Children.Count - 1; i++)
				if (!(n.Children[i] is LocalBase))
					return;

			if (!(n.Children[n.Children.Count - 1] is StmtBlock))
				return;

			n.Header = (LocalFuncDecl)n.Children[0];

			StmtBlock s = (StmtBlock)n.Children[n.Children.Count - 1];

			// for (int i = 0; i < s.getChildren().size(); i++) {
			//
			// NodeBase c = s.getChildren().get(i);
			//
			// if (!(c instanceof StmtBase))
			// return;
			//
			// s.getStmts().add((StmtBase) c);
			// }

			n.Block = s;

			for (int j = 1; j < n.Children.Count - 1; j++)
			{
				NodeBase c = n.Children[j];

				if (c is LocalVarDef)
				{
					n.VarDef = (LocalVarDef)c;

					getVars(c);
				}
				else if (c is LocalFuncDecl)
				{
					n.AddFuncDecl((LocalFuncDecl)c);
				}
				else if (c is LocalFuncDef)
				{
					n.AddFuncDef((LocalFuncDef)c);
				}
			}
		}

		private void getVars(NodeBase n)
		{
			if (!(n.Parent is LocalFuncDef))
				return;

			LocalFuncDef d = (LocalFuncDef)n.Parent;

			IList<string> vars = new List<string>();

			for (int i = 0; i < n.Children.Count; i++)
			{
				NodeBase p = n.Children[i];

				if (p is VarIdentifierT)
				{
					vars.Add(((VarIdentifierT)p).Text);
				}
				else if (p is HType)
				{
					addVars(d, vars, (HType)p);
				}
				else
				{
					return;
				}
			}
		}

		private void addVars(LocalFuncDef d, IList<string> vars, HType t)
		{
			TypeDataBase type = null;

			IList<int> dims = new List<int>();

			for (int i = 0; i < t.Children.Count; i++)
			{
				NodeBase c = t.Children[i];

				if (c is TypeDataBase)
				{
					type = (TypeDataBase)c;
				}
				else if (c is DimIntegerT)
				{
					dims.Add(((DimIntegerT)c).Dim);
				}
				else
				{
					return;
				}
			}

			if (type == null)
				return;

			for (int i = 0; i < vars.Count; i++)
				d.AddVar(new Variable(vars[i], type, dims));
		}

		public override void inAFuncLocalDef(AFuncLocalDef node)
		{
			defaultIn(node);
		}

		public override void outAFuncLocalDef(AFuncLocalDef node)
		{
			defaultOut(node);
		}

		public override void inAFuncDeclLocalDef(AFuncDeclLocalDef node)
		{
			defaultIn(node);
		}

		public override void outAFuncDeclLocalDef(AFuncDeclLocalDef node)
		{
			defaultOut(node);
		}

		public override void inAVarLocalDef(AVarLocalDef node)
		{
			defaultIn(node);
		}

		public override void outAVarLocalDef(AVarLocalDef node)
		{
			defaultOut(node);
		}
	}

}
