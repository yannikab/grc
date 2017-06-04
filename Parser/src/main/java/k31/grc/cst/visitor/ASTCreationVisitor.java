package k31.grc.cst.visitor;

import java.util.LinkedList;
import java.util.List;
import java.util.Stack;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.node.Parameter;
import k31.grc.ast.node.Variable;
import k31.grc.ast.node.cond.CondAnd;
import k31.grc.ast.node.cond.CondBase;
import k31.grc.ast.node.cond.CondEq;
import k31.grc.ast.node.cond.CondGe;
import k31.grc.ast.node.cond.CondGt;
import k31.grc.ast.node.cond.CondLe;
import k31.grc.ast.node.cond.CondLt;
import k31.grc.ast.node.cond.CondNe;
import k31.grc.ast.node.cond.CondNot;
import k31.grc.ast.node.cond.CondOr;
import k31.grc.ast.node.cond.CondRelOpBase;
import k31.grc.ast.node.expr.ExprAdd;
import k31.grc.ast.node.expr.ExprBase;
import k31.grc.ast.node.expr.ExprBinOpBase;
import k31.grc.ast.node.expr.ExprCharacterT;
import k31.grc.ast.node.expr.ExprDiv;
import k31.grc.ast.node.expr.ExprFuncCall;
import k31.grc.ast.node.expr.ExprIntegerT;
import k31.grc.ast.node.expr.ExprMinus;
import k31.grc.ast.node.expr.ExprMod;
import k31.grc.ast.node.expr.ExprMul;
import k31.grc.ast.node.expr.ExprPlus;
import k31.grc.ast.node.expr.ExprSub;
import k31.grc.ast.node.expr.LValueBase;
import k31.grc.ast.node.expr.LValueIdentifierT;
import k31.grc.ast.node.expr.LValueIndexed;
import k31.grc.ast.node.expr.LValueStringT;
import k31.grc.ast.node.func.FParIdentifierT;
import k31.grc.ast.node.func.LocalBase;
import k31.grc.ast.node.func.LocalFuncDecl;
import k31.grc.ast.node.func.LocalFuncDef;
import k31.grc.ast.node.func.LocalVarDef;
import k31.grc.ast.node.func.VarIdentifierT;
import k31.grc.ast.node.helper.Ref;
import k31.grc.ast.node.helper.Type;
import k31.grc.ast.node.helper.Val;
import k31.grc.ast.node.stmt.StmtAssign;
import k31.grc.ast.node.stmt.StmtBase;
import k31.grc.ast.node.stmt.StmtBlock;
import k31.grc.ast.node.stmt.StmtFuncCall;
import k31.grc.ast.node.stmt.StmtIfThen;
import k31.grc.ast.node.stmt.StmtIfThenElse;
import k31.grc.ast.node.stmt.StmtNoOpT;
import k31.grc.ast.node.stmt.StmtReturn;
import k31.grc.ast.node.stmt.StmtWhileDo;
import k31.grc.ast.node.type.DimEmptyT;
import k31.grc.ast.node.type.DimIntegerT;
import k31.grc.ast.node.type.TypeDataBase;
import k31.grc.ast.node.type.TypeDataCharT;
import k31.grc.ast.node.type.TypeDataIntT;
import k31.grc.ast.node.type.TypeReturnBase;
import k31.grc.ast.node.type.TypeReturnNothingT;
import k31.grc.cst.analysis.DepthFirstAdapter;
import k31.grc.cst.node.AAdditionExpression;
import k31.grc.cst.node.AAndOpTermL;
import k31.grc.cst.node.AArrayDim;
import k31.grc.cst.node.AArrayNoDim;
import k31.grc.cst.node.AAssignStmt;
import k31.grc.cst.node.ABlockStmt;
import k31.grc.cst.node.ACharDataType;
import k31.grc.cst.node.ACharacterFactor;
import k31.grc.cst.node.ADataReturnType;
import k31.grc.cst.node.ADivTerm;
import k31.grc.cst.node.AEqualFactorL;
import k31.grc.cst.node.AFparDef;
import k31.grc.cst.node.AFparDefMore;
import k31.grc.cst.node.AFparType;
import k31.grc.cst.node.AFuncDecl;
import k31.grc.cst.node.AFuncDeclLocalDef;
import k31.grc.cst.node.AFuncDef;
import k31.grc.cst.node.AFuncLocalDef;
import k31.grc.cst.node.AFuncParams;
import k31.grc.cst.node.AFunctionCall;
import k31.grc.cst.node.AFunctionCallStmt;
import k31.grc.cst.node.AGreaterEqualFactorL;
import k31.grc.cst.node.AGreaterThanFactorL;
import k31.grc.cst.node.AHeader;
import k31.grc.cst.node.AIdentifierLValue;
import k31.grc.cst.node.AIfStmtElse;
import k31.grc.cst.node.AIndexedLValue;
import k31.grc.cst.node.AIntDataType;
import k31.grc.cst.node.AIntegerFactor;
import k31.grc.cst.node.ALessEqualFactorL;
import k31.grc.cst.node.ALessThanFactorL;
import k31.grc.cst.node.AMinusFactor;
import k31.grc.cst.node.AModTerm;
import k31.grc.cst.node.AMultiplyTerm;
import k31.grc.cst.node.ANotEqualFactorL;
import k31.grc.cst.node.ANotOpFactorL;
import k31.grc.cst.node.ANothingReturnType;
import k31.grc.cst.node.AOrOpExpressionL;
import k31.grc.cst.node.AParMore;
import k31.grc.cst.node.APlusFactor;
import k31.grc.cst.node.AReturnStmt;
import k31.grc.cst.node.ASemicolonStmt;
import k31.grc.cst.node.AStringLValue;
import k31.grc.cst.node.ASubtractionExpression;
import k31.grc.cst.node.AThenElseIfStmt;
import k31.grc.cst.node.AThenIfStmt;
import k31.grc.cst.node.AType;
import k31.grc.cst.node.AVarDef;
import k31.grc.cst.node.AVarLocalDef;
import k31.grc.cst.node.AVarMore;
import k31.grc.cst.node.AWhileStmt;
import k31.grc.cst.node.AWhileStmtElse;
import k31.grc.cst.node.Node;
import k31.grc.cst.node.Start;

public class ASTCreationVisitor extends DepthFirstAdapter {

	private Stack<NodeBase> stack;

	public ASTCreationVisitor(NodeBase root) {

		stack = new Stack<NodeBase>();

		stack.push(root);
	}

	protected void pushNode(NodeBase node) {

		stack.peek().addChild(node);

		stack.push(node);
	}

	protected void popNode() {

		stack.pop();
	}

	protected NodeBase getNode() {

		return stack.peek();
	}

	@Override
	public void inStart(Start node) {
		defaultIn(node);
	}

	@Override
	public void outStart(Start node) {
		defaultOut(node);
	}

	public void defaultIn(@SuppressWarnings("unused") Node node) {
		// Do nothing
	}

	public void defaultOut(@SuppressWarnings("unused") Node node) {
		// Do nothing
	}

	private void outExprBinOp() {

		ExprBinOpBase n = (ExprBinOpBase) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof ExprBase && n.getChildren().get(1) instanceof ExprBase))
			return;

		n.setLeft((ExprBase) n.getChildren().get(0));
		n.setRight((ExprBase) n.getChildren().get(1));
	}

	@Override
	public void inAAdditionExpression(AAdditionExpression node) {
		defaultIn(node);

		pushNode(new ExprAdd(node.getOperPlus().getText()));
	}

	@Override
	public void outAAdditionExpression(AAdditionExpression node) {
		defaultOut(node);

		outExprBinOp();
	}

	@Override
	public void inASubtractionExpression(ASubtractionExpression node) {
		defaultIn(node);

		pushNode(new ExprSub(node.getOperMinus().getText()));
	}

	@Override
	public void outASubtractionExpression(ASubtractionExpression node) {
		defaultOut(node);

		outExprBinOp();
	}

	@Override
	public void inAMultiplyTerm(AMultiplyTerm node) {
		defaultIn(node);

		pushNode(new ExprMul(node.getOperMul().getText()));
	}

	@Override
	public void outAMultiplyTerm(AMultiplyTerm node) {
		defaultOut(node);

		outExprBinOp();
	}

	@Override
	public void inADivTerm(ADivTerm node) {
		defaultIn(node);

		pushNode(new ExprDiv(node.getOperDiv().getText()));
	}

	@Override
	public void outADivTerm(ADivTerm node) {
		defaultOut(node);

		outExprBinOp();
	}

	@Override
	public void inAModTerm(AModTerm node) {
		defaultIn(node);

		pushNode(new ExprMod(node.getOperMod().getText()));
	}

	@Override
	public void outAModTerm(AModTerm node) {
		defaultOut(node);

		outExprBinOp();
	}

	@Override
	public void inAIntegerFactor(AIntegerFactor node) {
		defaultIn(node);

		pushNode(new ExprIntegerT(node.getInteger().getText()));
	}

	@Override
	public void outAIntegerFactor(AIntegerFactor node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inACharacterFactor(ACharacterFactor node) {
		defaultIn(node);

		pushNode(new ExprCharacterT(node.getCharacter().getText()));
	}

	@Override
	public void outACharacterFactor(ACharacterFactor node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAPlusFactor(APlusFactor node) {
		defaultIn(node);

		pushNode(new ExprPlus(node.getOperPlus().getText()));
	}

	@Override
	public void outAPlusFactor(APlusFactor node) {
		defaultOut(node);

		ExprPlus n = (ExprPlus) getNode();
		popNode();

		if (n.getChildren().size() != 1)
			return;

		if (!(n.getChildren().get(0) instanceof ExprBase))
			return;

		n.setExpr((ExprBase) n.getChildren().get(0));
	}

	@Override
	public void inAMinusFactor(AMinusFactor node) {
		defaultIn(node);

		pushNode(new ExprMinus(node.getOperMinus().getText()));
	}

	@Override
	public void outAMinusFactor(AMinusFactor node) {
		defaultOut(node);

		ExprMinus n = (ExprMinus) getNode();
		popNode();

		if (n.getChildren().size() != 1)
			return;

		if (!(n.getChildren().get(0) instanceof ExprBase))
			return;

		n.setExpr((ExprBase) n.getChildren().get(0));
	}

	@Override
	public void inAIndexedLValue(AIndexedLValue node) {
		defaultIn(node);

		pushNode(new LValueIndexed(String.format("%s%s", node.getSepLbrack().getText(), node.getSepRbrack().getText())));
	}

	@Override
	public void outAIndexedLValue(AIndexedLValue node) {
		defaultOut(node);

		LValueIndexed n = (LValueIndexed) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof LValueBase))
			return;

		if (!(n.getChildren().get(1) instanceof ExprBase))
			return;

		n.setLval((LValueBase) n.getChildren().get(0));
		n.setExpr((ExprBase) n.getChildren().get(1));
	}

	@Override
	public void inAStringLValue(AStringLValue node) {
		defaultIn(node);

		pushNode(new LValueStringT(node.getString().getText()));
	}

	@Override
	public void outAStringLValue(AStringLValue node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIdentifierLValue(AIdentifierLValue node) {
		defaultIn(node);

		pushNode(new LValueIdentifierT(node.getIdentifier().getText()));
	}

	@Override
	public void outAIdentifierLValue(AIdentifierLValue node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFunctionCall(AFunctionCall node) {
		defaultIn(node);

		pushNode(new ExprFuncCall(String.format("%s%s%s", node.getIdentifier().getText(), node.getSepLpar().getText(), node.getSepRpar().getText())));
	}

	@Override
	public void outAFunctionCall(AFunctionCall node) {
		defaultOut(node);

		ExprFuncCall n = (ExprFuncCall) getNode();

		popNode();

		for (int i = 0; i < n.getChildren().size(); i++)
			if (!(n.getChildren().get(i) instanceof ExprBase))
				return;

		for (int i = 0; i < n.getChildren().size(); i++)
			n.getArgs().add((ExprBase) n.getChildren().get(i));
	}

	@Override
	public void inAOrOpExpressionL(AOrOpExpressionL node) {
		defaultIn(node);

		pushNode(new CondOr(node.getOperOr().getText()));
	}

	@Override
	public void outAOrOpExpressionL(AOrOpExpressionL node) {
		defaultOut(node);

		CondOr n = (CondOr) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof CondBase && n.getChildren().get(1) instanceof CondBase))
			return;

		n.setLeft((CondBase) n.getChildren().get(0));
		n.setRight((CondBase) n.getChildren().get(1));
	}

	@Override
	public void inAAndOpTermL(AAndOpTermL node) {
		defaultIn(node);

		pushNode(new CondAnd(node.getOperAnd().getText()));
	}

	@Override
	public void outAAndOpTermL(AAndOpTermL node) {
		defaultOut(node);

		CondAnd n = (CondAnd) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof CondBase && n.getChildren().get(1) instanceof CondBase))
			return;

		n.setLeft((CondBase) n.getChildren().get(0));
		n.setRight((CondBase) n.getChildren().get(1));
	}

	@Override
	public void inANotOpFactorL(ANotOpFactorL node) {
		defaultIn(node);

		pushNode(new CondNot(node.getOperNot().getText()));
	}

	@Override
	public void outANotOpFactorL(ANotOpFactorL node) {
		defaultOut(node);

		CondNot n = (CondNot) getNode();
		popNode();

		if (n.getChildren().size() != 1)
			return;

		if (!(n.getChildren().get(0) instanceof CondBase))
			return;

		n.setCond((CondBase) n.getChildren().get(0));
	}

	private void outCondRelOp() {

		CondRelOpBase n = (CondRelOpBase) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof ExprBase && n.getChildren().get(1) instanceof ExprBase))
			return;

		n.setLeft((ExprBase) n.getChildren().get(0));
		n.setRight((ExprBase) n.getChildren().get(1));
	}

	@Override
	public void inAEqualFactorL(AEqualFactorL node) {
		defaultIn(node);

		pushNode(new CondEq(node.getOperEq().getText()));
	}

	@Override
	public void outAEqualFactorL(AEqualFactorL node) {
		defaultOut(node);

		outCondRelOp();
	}

	@Override
	public void inANotEqualFactorL(ANotEqualFactorL node) {
		defaultIn(node);

		pushNode(new CondNe(node.getOperNe().getText()));
	}

	@Override
	public void outANotEqualFactorL(ANotEqualFactorL node) {
		defaultOut(node);

		outCondRelOp();
	}

	@Override
	public void inAGreaterThanFactorL(AGreaterThanFactorL node) {
		defaultIn(node);

		pushNode(new CondGt(node.getOperGt().getText()));
	}

	@Override
	public void outAGreaterThanFactorL(AGreaterThanFactorL node) {
		defaultOut(node);

		outCondRelOp();
	}

	@Override
	public void inALessThanFactorL(ALessThanFactorL node) {
		defaultIn(node);

		pushNode(new CondLt(node.getOperLt().getText()));
	}

	@Override
	public void outALessThanFactorL(ALessThanFactorL node) {
		defaultOut(node);

		outCondRelOp();
	}

	@Override
	public void inAGreaterEqualFactorL(AGreaterEqualFactorL node) {
		defaultIn(node);

		pushNode(new CondGe(node.getOperGe().getText()));
	}

	@Override
	public void outAGreaterEqualFactorL(AGreaterEqualFactorL node) {
		defaultOut(node);

		outCondRelOp();
	}

	@Override
	public void inALessEqualFactorL(ALessEqualFactorL node) {
		defaultIn(node);

		pushNode(new CondLe(node.getOperLe().getText()));
	}

	@Override
	public void outALessEqualFactorL(ALessEqualFactorL node) {
		defaultOut(node);

		outCondRelOp();
	}

	@Override
	public void inASemicolonStmt(ASemicolonStmt node) {
		defaultIn(node);

		pushNode(new StmtNoOpT(node.getSepSemi().getText()));
	}

	@Override
	public void outASemicolonStmt(ASemicolonStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAAssignStmt(AAssignStmt node) {
		defaultIn(node);

		pushNode(new StmtAssign(node.getSepAssign().getText()));
	}

	@Override
	public void outAAssignStmt(AAssignStmt node) {
		defaultOut(node);

		StmtAssign n = (StmtAssign) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof LValueBase))
			return;

		if (!(n.getChildren().get(1) instanceof ExprBase))
			return;

		n.setLval((LValueBase) n.getChildren().get(0));
		n.setExpr((ExprBase) n.getChildren().get(1));
	}

	@Override
	public void inABlockStmt(ABlockStmt node) {
		defaultIn(node);

		pushNode(new StmtBlock(String.format("%s %s", node.getSepLbrace().getText(), node.getSepRbrace().getText())));
	}

	@Override
	public void outABlockStmt(ABlockStmt node) {
		defaultOut(node);

		StmtBlock n = (StmtBlock) getNode();
		popNode();

		for (int i = 0; i < n.getChildren().size(); i++)
			if (!(n.getChildren().get(i) instanceof StmtBase))
				return;

		for (int i = 0; i < n.getChildren().size(); i++)
			n.getStmts().add((StmtBase) n.getChildren().get(i));
	}

	@Override
	public void inAFunctionCallStmt(AFunctionCallStmt node) {
		defaultIn(node);

		pushNode(new StmtFuncCall());
	}

	@Override
	public void outAFunctionCallStmt(AFunctionCallStmt node) {
		defaultOut(node);

		StmtFuncCall n = (StmtFuncCall) getNode();
		popNode();

		if (n.getChildren().size() != 1 || !(n.getChildren().get(0) instanceof ExprFuncCall))
			return;

		ExprFuncCall c = (ExprFuncCall) n.getChildren().get(0);

		n.setId(c.getId());

		for (int i = 0; i < c.getChildren().size(); i++)
			if (!(c.getChildren().get(i) instanceof ExprBase))
				return;

		for (int i = 0; i < c.getChildren().size(); i++)
			n.getArgs().add((ExprBase) c.getChildren().get(i));
	}

	@Override
	public void inAReturnStmt(AReturnStmt node) {
		defaultIn(node);

		pushNode(new StmtReturn(node.getKeyReturn().getText()));
	}

	@Override
	public void outAReturnStmt(AReturnStmt node) {
		defaultOut(node);

		StmtReturn n = (StmtReturn) getNode();
		popNode();

		if (n.getChildren().size() > 1)
			return;

		if (n.getChildren().size() == 1 && !(n.getChildren().get(0) instanceof ExprBase))
			return;

		n.setExpr(n.getChildren().size() == 1 ? (ExprBase) n.getChildren().get(0) : null);
	}

	@Override
	public void inAThenIfStmt(AThenIfStmt node) {
		defaultIn(node);

		pushNode(new StmtIfThen(String.format("%s-%s", node.getKeyIf().getText(), node.getKeyThen().getText())));
	}

	@Override
	public void outAThenIfStmt(AThenIfStmt node) {
		defaultOut(node);

		StmtIfThen n = (StmtIfThen) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof CondBase))
			return;

		if (!(n.getChildren().get(1) instanceof StmtBase))
			return;

		n.setCond((CondBase) n.getChildren().get(0));
		n.setStmt((StmtBase) n.getChildren().get(1));
	}

	private void outStmtIfThenElse() {
		StmtIfThenElse n = (StmtIfThenElse) getNode();
		popNode();

		if (n.getChildren().size() != 3)
			return;

		if (!(n.getChildren().get(0) instanceof CondBase))
			return;

		if (!(n.getChildren().get(1) instanceof StmtBase && n.getChildren().get(2) instanceof StmtBase))
			return;

		n.setCond((CondBase) n.getChildren().get(0));
		n.setStmtThen((StmtBase) n.getChildren().get(1));
		n.setStmtElse((StmtBase) n.getChildren().get(2));
	}

	@Override
	public void inAThenElseIfStmt(AThenElseIfStmt node) {
		defaultIn(node);

		pushNode(new StmtIfThenElse(String.format("%s-%s-%s", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText())));
	}

	@Override
	public void outAThenElseIfStmt(AThenElseIfStmt node) {
		defaultOut(node);

		outStmtIfThenElse();
	}

	@Override
	public void inAIfStmtElse(AIfStmtElse node) {
		defaultIn(node);

		pushNode(new StmtIfThenElse(String.format("%s-%s-%s", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText())));
	}

	@Override
	public void outAIfStmtElse(AIfStmtElse node) {
		defaultOut(node);

		outStmtIfThenElse();
	}

	private void outStmtWhileDo() {
		StmtWhileDo n = (StmtWhileDo) getNode();
		popNode();

		if (n.getChildren().size() != 2)
			return;

		if (!(n.getChildren().get(0) instanceof CondBase))
			return;

		if (!(n.getChildren().get(1) instanceof StmtBase))
			return;

		n.setCond((CondBase) n.getChildren().get(0));
		n.setStmt((StmtBase) n.getChildren().get(1));

	}

	@Override
	public void inAWhileStmt(AWhileStmt node) {
		defaultIn(node);

		pushNode(new StmtWhileDo(String.format("%s-%s", node.getKeyWhile().getText(), node.getKeyDo().getText())));
	}

	@Override
	public void outAWhileStmt(AWhileStmt node) {
		defaultOut(node);

		outStmtWhileDo();
	}

	@Override
	public void inAWhileStmtElse(AWhileStmtElse node) {
		defaultIn(node);

		pushNode(new StmtWhileDo(String.format("%s-%s", node.getKeyWhile().getText(), node.getKeyDo().getText())));
	}

	@Override
	public void outAWhileStmtElse(AWhileStmtElse node) {
		defaultOut(node);

		outStmtWhileDo();
	}

	@Override
	public void inACharDataType(ACharDataType node) {
		defaultIn(node);

		pushNode(new TypeDataCharT(node.getKeyChar().getText()));
	}

	@Override
	public void outACharDataType(ACharDataType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIntDataType(AIntDataType node) {
		defaultIn(node);

		pushNode(new TypeDataIntT(node.getKeyInt().getText()));
	}

	@Override
	public void outAIntDataType(AIntDataType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inADataReturnType(ADataReturnType node) {
		defaultIn(node);

		pushNode(new Type());
	}

	@Override
	public void outADataReturnType(ADataReturnType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inANothingReturnType(ANothingReturnType node) {
		defaultIn(node);

		pushNode(new Type());

		pushNode(new TypeReturnNothingT((node.getKeyNothing().getText())));
		popNode();
	}

	@Override
	public void outANothingReturnType(ANothingReturnType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAArrayNoDim(AArrayNoDim node) {
		defaultIn(node);

		pushNode(new DimEmptyT(String.format("%s%s", node.getSepLbrack().getText(), node.getSepRbrack().getText())));
	}

	@Override
	public void outAArrayNoDim(AArrayNoDim node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAArrayDim(AArrayDim node) {
		defaultIn(node);

		pushNode(new DimIntegerT(String.format("%s%s%s", node.getSepLbrack().getText(), node.getInteger().getText(), node.getSepRbrack().getText())));
	}

	@Override
	public void outAArrayDim(AArrayDim node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAType(AType node) {
		defaultIn(node);

		pushNode(new Type());
	}

	@Override
	public void outAType(AType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAVarDef(AVarDef node) {
		defaultIn(node);

		pushNode(new LocalVarDef(node.getKeyVar().getText()));

		pushNode(new VarIdentifierT(node.getIdentifier().getText()));
		popNode();
	}

	@Override
	public void outAVarDef(AVarDef node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAVarMore(AVarMore node) {
		defaultIn(node);

		pushNode(new VarIdentifierT(node.getIdentifier().getText()));
	}

	@Override
	public void outAVarMore(AVarMore node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFparType(AFparType node) {
		defaultIn(node);

		pushNode(new Type());
	}

	@Override
	public void outAFparType(AFparType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFparDef(AFparDef node) {
		defaultIn(node);

		pushNode(node.getKeyRef() != null ? new Ref() : new Val());

		pushNode(new FParIdentifierT(node.getIdentifier().getText()));
		popNode();
	}

	@Override
	public void outAFparDef(AFparDef node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAParMore(AParMore node) {
		defaultIn(node);

		pushNode(new FParIdentifierT(node.getIdentifier().getText()));
	}

	@Override
	public void outAParMore(AParMore node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAHeader(AHeader node) {
		defaultIn(node);

		pushNode(new LocalFuncDecl(String.format("%s%s%s", node.getIdentifier().getText(), node.getSepLpar().getText(), node.getSepRpar().getText())));
	}

	@Override
	public void outAHeader(AHeader node) {
		defaultOut(node);

		LocalFuncDecl n = (LocalFuncDecl) getNode();

		popNode();

		processFuncDecl(n);
	}

	private void processFuncDecl(LocalFuncDecl n) {

		if (n.getChildren().size() < 1)
			return;

		for (int i = 0; i < n.getChildren().size(); i++) {

			NodeBase c = n.getChildren().get(i);

			if (c instanceof Ref) {

				getParams(c, true);

			} else if (c instanceof Val) {

				getParams(c, false);

			} else if (c instanceof Type) {

				getReturnType((Type) c);

			} else {

				return;
			}
		}
	}

	private void getParams(NodeBase n, boolean ref) {

		if (!(n.getParent() instanceof LocalFuncDecl))
			return;

		LocalFuncDecl d = (LocalFuncDecl) n.getParent();

		List<String> params = new LinkedList<String>();

		for (int i = 0; i < n.getChildren().size(); i++) {

			NodeBase p = n.getChildren().get(i);

			if (p instanceof FParIdentifierT) {

				params.add(((FParIdentifierT) p).getText());

			} else if (p instanceof Type) {

				addParams(d, ref, params, (Type) p);

			} else {

				return;
			}
		}
	}

	private void addParams(LocalFuncDecl d, boolean ref, List<String> params, Type t) {

		TypeDataBase type = null;

		boolean dimEmpty = false;

		List<Integer> dims = new LinkedList<Integer>();

		for (int i = 0; i < t.getChildren().size(); i++) {

			NodeBase c = t.getChildren().get(i);

			if (c instanceof TypeDataBase) {

				type = (TypeDataBase) c;

			} else if (c instanceof DimEmptyT) {

				if (dimEmpty)
					return;

				dimEmpty = true;

			} else if (c instanceof DimIntegerT) {

				dims.add(((DimIntegerT) c).getDim());

			} else {

				return;
			}
		}

		if (type == null)
			return;

		for (int i = 0; i < params.size(); i++)
			d.getParams().add(new Parameter(params.get(i), ref, type, dimEmpty, dims));
	}

	private void getReturnType(Type n) {

		if (!(n.getParent() instanceof LocalFuncDecl))
			return;

		LocalFuncDecl d = (LocalFuncDecl) n.getParent();

		if (n.getChildren().size() != 1)
			return;

		NodeBase t = n.getChildren().get(0);

		if (!(t instanceof TypeReturnBase))
			return;

		d.setReturnType((TypeReturnBase) t);
	}

	@Override
	public void inAFuncParams(AFuncParams node) {
		defaultIn(node);
	}

	@Override
	public void outAFuncParams(AFuncParams node) {
		defaultOut(node);
	}

	@Override
	public void inAFparDefMore(AFparDefMore node) {
		defaultIn(node);
	}

	@Override
	public void outAFparDefMore(AFparDefMore node) {
		defaultOut(node);
	}

	@Override
	public void inAFuncDecl(AFuncDecl node) {
		defaultIn(node);
	}

	@Override
	public void outAFuncDecl(AFuncDecl node) {
		defaultOut(node);
	}

	@Override
	public void inAFuncDef(AFuncDef node) {
		defaultIn(node);

		pushNode(new LocalFuncDef());
	}

	@Override
	public void outAFuncDef(AFuncDef node) {
		defaultOut(node);

		LocalFuncDef n = (LocalFuncDef) getNode();

		popNode();

		if (n.getChildren().size() < 2)
			return;

		if (!(n.getChildren().get(0) instanceof LocalFuncDecl))
			return;

		for (int i = 1; i < n.getChildren().size() - 1; i++)
			if (!(n.getChildren().get(i) instanceof LocalBase))
				return;

		if (!(n.getChildren().get(n.getChildren().size() - 1) instanceof StmtBlock))
			return;

		n.setHeader((LocalFuncDecl) n.getChildren().get(0));

		StmtBlock s = (StmtBlock) n.getChildren().get(n.getChildren().size() - 1);

		// for (int i = 0; i < s.getChildren().size(); i++) {
		//
		// NodeBase c = s.getChildren().get(i);
		//
		// if (!(c instanceof StmtBase))
		// return;
		//
		// s.getStmts().add((StmtBase) c);
		// }

		n.setBlock(s);

		for (int j = 1; j < n.getChildren().size() - 1; j++) {

			NodeBase c = n.getChildren().get(j);

			if (c instanceof LocalVarDef) {

				n.setVarDef((LocalVarDef) c);

				getVars(c);

			} else if (c instanceof LocalFuncDecl) {

				n.getFuncDecls().add((LocalFuncDecl) c);

			} else if (c instanceof LocalFuncDef) {

				n.getFuncDefs().add((LocalFuncDef) c);
			}
		}
	}

	private void getVars(NodeBase n) {

		if (!(n.getParent() instanceof LocalFuncDef))
			return;

		LocalFuncDef d = (LocalFuncDef) n.getParent();

		List<String> vars = new LinkedList<String>();

		for (int i = 0; i < n.getChildren().size(); i++) {

			NodeBase p = n.getChildren().get(i);

			if (p instanceof VarIdentifierT) {

				vars.add(((VarIdentifierT) p).getText());

			} else if (p instanceof Type) {

				addVars(d, vars, (Type) p);

			} else {

				return;
			}
		}
	}

	private void addVars(LocalFuncDef d, List<String> vars, Type t) {

		TypeDataBase type = null;

		List<Integer> dims = new LinkedList<Integer>();

		for (int i = 0; i < t.getChildren().size(); i++) {

			NodeBase c = t.getChildren().get(i);

			if (c instanceof TypeDataBase) {

				type = (TypeDataBase) c;

			} else if (c instanceof DimIntegerT) {

				dims.add(((DimIntegerT) c).getDim());

			} else {

				return;
			}
		}

		if (type == null)
			return;

		for (int i = 0; i < vars.size(); i++)
			d.getVars().add(new Variable(vars.get(i), type, dims));
	}

	@Override
	public void inAFuncLocalDef(AFuncLocalDef node) {
		defaultIn(node);
	}

	@Override
	public void outAFuncLocalDef(AFuncLocalDef node) {
		defaultOut(node);
	}

	@Override
	public void inAFuncDeclLocalDef(AFuncDeclLocalDef node) {
		defaultIn(node);
	}

	@Override
	public void outAFuncDeclLocalDef(AFuncDeclLocalDef node) {
		defaultOut(node);
	}

	@Override
	public void inAVarLocalDef(AVarLocalDef node) {
		defaultIn(node);
	}

	@Override
	public void outAVarLocalDef(AVarLocalDef node) {
		defaultOut(node);
	}
}
