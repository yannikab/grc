package k31.grc.cst.visitor;

import java.util.Stack;

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
import k31.grc.cst.node.AFparType;
import k31.grc.cst.node.AFuncDecl;
import k31.grc.cst.node.AFuncDef;
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
import k31.grc.cst.node.AVarMore;
import k31.grc.cst.node.AWhileStmt;
import k31.grc.cst.node.AWhileStmtElse;

public class GraphVizTraversalAST extends DepthFirstAdapter {

	private static int nodeNumber = 0;

	private Stack<GVNode> stack;

	public GraphVizTraversalAST(GVNode root) {

		stack = new Stack<GVNode>();

		stack.push(root);
	}

	protected void pushNode(String text) {

		GVNode n = new GVNode(nodeNumber++, text);
		stack.peek().addChild(n);
		stack.push(n);
	}

	protected void popNode() {

		stack.pop();
	}

	@Override
	public void inAAdditionExpression(AAdditionExpression node) {
		defaultIn(node);

		pushNode(node.getOperPlus().getText());
	}

	@Override
	public void outAAdditionExpression(AAdditionExpression node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inASubtractionExpression(ASubtractionExpression node) {
		defaultIn(node);

		pushNode(node.getOperMinus().getText());
	}

	@Override
	public void outASubtractionExpression(ASubtractionExpression node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAMultiplyTerm(AMultiplyTerm node) {
		defaultIn(node);

		pushNode(node.getOperMul().getText());
	}

	@Override
	public void outAMultiplyTerm(AMultiplyTerm node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inADivTerm(ADivTerm node) {
		defaultIn(node);

		pushNode(node.getOperDiv().getText());
	}

	@Override
	public void outADivTerm(ADivTerm node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAModTerm(AModTerm node) {
		defaultIn(node);

		pushNode(node.getOperMod().getText());
	}

	@Override
	public void outAModTerm(AModTerm node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIntegerFactor(AIntegerFactor node) {
		defaultIn(node);

		pushNode(node.getInteger().getText());
	}

	@Override
	public void outAIntegerFactor(AIntegerFactor node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inACharacterFactor(ACharacterFactor node) {
		defaultIn(node);

		pushNode(node.getCharacter().getText());
	}

	@Override
	public void outACharacterFactor(ACharacterFactor node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAPlusFactor(APlusFactor node) {
		defaultIn(node);

		pushNode(node.getOperPlus().getText());
	}

	@Override
	public void outAPlusFactor(APlusFactor node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAMinusFactor(AMinusFactor node) {
		defaultIn(node);

		pushNode(node.getOperMinus().getText());
	}

	@Override
	public void outAMinusFactor(AMinusFactor node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIndexedLValue(AIndexedLValue node) {
		defaultIn(node);

		pushNode(node.getClass().getSimpleName().substring(1));
	}

	@Override
	public void outAIndexedLValue(AIndexedLValue node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAStringLValue(AStringLValue node) {
		defaultIn(node);

		pushNode(node.getString().getText());
	}

	@Override
	public void outAStringLValue(AStringLValue node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIdentifierLValue(AIdentifierLValue node) {
		defaultIn(node);

		pushNode(node.getIdentifier().getText());
	}

	@Override
	public void outAIdentifierLValue(AIdentifierLValue node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFunctionCall(AFunctionCall node) {
		defaultIn(node);

		pushNode(node.getIdentifier().getText() + "()");
	}

	@Override
	public void outAFunctionCall(AFunctionCall node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAOrOpExpressionL(AOrOpExpressionL node) {
		defaultIn(node);

		pushNode(node.getOperOr().getText());
	}

	@Override
	public void outAOrOpExpressionL(AOrOpExpressionL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAAndOpTermL(AAndOpTermL node) {
		defaultIn(node);

		pushNode(node.getOperAnd().getText());
	}

	@Override
	public void outAAndOpTermL(AAndOpTermL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inANotOpFactorL(ANotOpFactorL node) {
		defaultIn(node);

		pushNode(node.getOperNot().getText());
	}

	@Override
	public void outANotOpFactorL(ANotOpFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAEqualFactorL(AEqualFactorL node) {
		defaultIn(node);

		pushNode(node.getOperEq().getText());
	}

	@Override
	public void outAEqualFactorL(AEqualFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inANotEqualFactorL(ANotEqualFactorL node) {
		defaultIn(node);

		pushNode(node.getOperNe().getText());
	}

	@Override
	public void outANotEqualFactorL(ANotEqualFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAGreaterThanFactorL(AGreaterThanFactorL node) {
		defaultIn(node);

		pushNode(node.getOperGt().getText());
	}

	@Override
	public void outAGreaterThanFactorL(AGreaterThanFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inALessThanFactorL(ALessThanFactorL node) {
		defaultIn(node);

		pushNode(node.getOperLt().getText());
	}

	@Override
	public void outALessThanFactorL(ALessThanFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAGreaterEqualFactorL(AGreaterEqualFactorL node) {
		defaultIn(node);

		pushNode(node.getOperGe().getText());
	}

	@Override
	public void outAGreaterEqualFactorL(AGreaterEqualFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inALessEqualFactorL(ALessEqualFactorL node) {
		defaultIn(node);

		pushNode(node.getOperLe().getText());
	}

	@Override
	public void outALessEqualFactorL(ALessEqualFactorL node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inASemicolonStmt(ASemicolonStmt node) {
		defaultIn(node);

		pushNode(node.getSepSemi().getText());
	}

	@Override
	public void outASemicolonStmt(ASemicolonStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAAssignStmt(AAssignStmt node) {
		defaultIn(node);

		pushNode(node.getSepAssign().getText());
	}

	@Override
	public void outAAssignStmt(AAssignStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inABlockStmt(ABlockStmt node) {
		defaultIn(node);

		pushNode(String.format("%s %s", node.getSepLbrace().getText(), node.getSepRbrace().getText()));
	}

	@Override
	public void outABlockStmt(ABlockStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFunctionCallStmt(AFunctionCallStmt node) {
		defaultIn(node);

		// pushNode("()");
	}

	@Override
	public void outAFunctionCallStmt(AFunctionCallStmt node) {
		defaultOut(node);

		// popNode();
	}

	@Override
	public void inAReturnStmt(AReturnStmt node) {
		defaultIn(node);

		pushNode(node.getKeyReturn().getText());
	}

	@Override
	public void outAReturnStmt(AReturnStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAThenIfStmt(AThenIfStmt node) {
		defaultIn(node);

		pushNode(String.format("%s-%s", node.getKeyIf().getText(), node.getKeyThen().getText()));
	}

	@Override
	public void outAThenIfStmt(AThenIfStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAThenElseIfStmt(AThenElseIfStmt node) {
		defaultIn(node);

		pushNode(String.format("%s-%s-%s", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText()));
	}

	@Override
	public void outAThenElseIfStmt(AThenElseIfStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIfStmtElse(AIfStmtElse node) {
		defaultIn(node);

		pushNode(String.format("%s-%s-%s", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText()));
	}

	@Override
	public void outAIfStmtElse(AIfStmtElse node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAWhileStmt(AWhileStmt node) {
		defaultIn(node);

		pushNode(String.format("%s-%s", node.getKeyWhile().getText(), node.getKeyDo().getText()));
	}

	@Override
	public void outAWhileStmt(AWhileStmt node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAWhileStmtElse(AWhileStmtElse node) {
		defaultIn(node);

		pushNode(String.format("%s-%s", node.getKeyWhile().getText(), node.getKeyDo().getText()));
	}

	@Override
	public void outAWhileStmtElse(AWhileStmtElse node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inACharDataType(ACharDataType node) {
		defaultIn(node);

		pushNode(node.getKeyChar().getText());
	}

	@Override
	public void outACharDataType(ACharDataType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAIntDataType(AIntDataType node) {
		defaultIn(node);

		pushNode(node.getKeyInt().getText());
	}

	@Override
	public void outAIntDataType(AIntDataType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inADataReturnType(ADataReturnType node) {
		defaultIn(node);

		pushNode("type");
	}

	@Override
	public void outADataReturnType(ADataReturnType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inANothingReturnType(ANothingReturnType node) {
		defaultIn(node);

		pushNode("type");
		pushNode(node.getKeyNothing().getText());
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

		pushNode(String.format("%s%s", node.getSepLbrack().getText(), node.getSepRbrack().getText()));
	}

	@Override
	public void outAArrayNoDim(AArrayNoDim node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAArrayDim(AArrayDim node) {
		defaultIn(node);

		pushNode(String.format("%s%s%s", node.getSepLbrack().getText(), node.getInteger().getText(), node.getSepRbrack().getText()));
	}

	@Override
	public void outAArrayDim(AArrayDim node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAType(AType node) {
		defaultIn(node);

		pushNode("type");
	}

	@Override
	public void outAType(AType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAVarDef(AVarDef node) {
		defaultIn(node);

		pushNode(node.getKeyVar().getText());
		pushNode(node.getIdentifier().getText());
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

		pushNode(node.getIdentifier().getText());
	}

	@Override
	public void outAVarMore(AVarMore node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFparType(AFparType node) {
		defaultIn(node);

		pushNode("type");
	}

	@Override
	public void outAFparType(AFparType node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFparDef(AFparDef node) {
		defaultIn(node);

		pushNode(node.getKeyRef() != null ? node.getKeyRef().getText() : "val");
		pushNode(node.getIdentifier().getText());
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

		pushNode(node.getIdentifier().getText());
	}

	@Override
	public void outAParMore(AParMore node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAHeader(AHeader node) {
		defaultIn(node);

		pushNode(String.format("%s%s%s", node.getIdentifier(), node.getSepLpar(), node.getSepRpar()));
	}

	@Override
	public void outAHeader(AHeader node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFuncDecl(AFuncDecl node) {
		defaultIn(node);

		pushNode("func-decl");
	}

	@Override
	public void outAFuncDecl(AFuncDecl node) {
		defaultOut(node);

		popNode();
	}

	@Override
	public void inAFuncDef(AFuncDef node) {
		defaultIn(node);

		pushNode("func-def");
	}

	@Override
	public void outAFuncDef(AFuncDef node) {
		defaultOut(node);

		popNode();
	}
}
