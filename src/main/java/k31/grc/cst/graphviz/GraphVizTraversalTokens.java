package k31.grc.cst.graphviz;

import k31.grc.cst.node.TCharacter;
import k31.grc.cst.node.TIdentifier;
import k31.grc.cst.node.TInteger;
import k31.grc.cst.node.TKeyChar;
import k31.grc.cst.node.TKeyDo;
import k31.grc.cst.node.TKeyElse;
import k31.grc.cst.node.TKeyFun;
import k31.grc.cst.node.TKeyIf;
import k31.grc.cst.node.TKeyInt;
import k31.grc.cst.node.TKeyNothing;
import k31.grc.cst.node.TKeyRef;
import k31.grc.cst.node.TKeyReturn;
import k31.grc.cst.node.TKeyThen;
import k31.grc.cst.node.TKeyVar;
import k31.grc.cst.node.TKeyWhile;
import k31.grc.cst.node.TOperAnd;
import k31.grc.cst.node.TOperDiv;
import k31.grc.cst.node.TOperEq;
import k31.grc.cst.node.TOperGe;
import k31.grc.cst.node.TOperGt;
import k31.grc.cst.node.TOperLe;
import k31.grc.cst.node.TOperLt;
import k31.grc.cst.node.TOperMinus;
import k31.grc.cst.node.TOperMod;
import k31.grc.cst.node.TOperMul;
import k31.grc.cst.node.TOperNe;
import k31.grc.cst.node.TOperNot;
import k31.grc.cst.node.TOperOr;
import k31.grc.cst.node.TOperPlus;
import k31.grc.cst.node.TSepAssign;
import k31.grc.cst.node.TSepColon;
import k31.grc.cst.node.TSepComma;
import k31.grc.cst.node.TSepLbrace;
import k31.grc.cst.node.TSepLbrack;
import k31.grc.cst.node.TSepLpar;
import k31.grc.cst.node.TSepRbrace;
import k31.grc.cst.node.TSepRbrack;
import k31.grc.cst.node.TSepRpar;
import k31.grc.cst.node.TSepSemi;
import k31.grc.cst.node.TString;

public class GraphVizTraversalTokens extends GraphVizTraversal {

	public GraphVizTraversalTokens(GVNode root) {
		super(root);
	}

	@Override
	public void caseTInteger(TInteger node) {
		// TODO Auto-generated method stub
		super.caseTInteger(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTCharacter(TCharacter node) {
		// TODO Auto-generated method stub
		super.caseTCharacter(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTString(TString node) {
		// TODO Auto-generated method stub
		super.caseTString(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperPlus(TOperPlus node) {
		// TODO Auto-generated method stub
		super.caseTOperPlus(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperMinus(TOperMinus node) {
		// TODO Auto-generated method stub
		super.caseTOperMinus(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperMul(TOperMul node) {
		// TODO Auto-generated method stub
		super.caseTOperMul(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperDiv(TOperDiv node) {
		// TODO Auto-generated method stub
		super.caseTOperDiv(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperMod(TOperMod node) {
		// TODO Auto-generated method stub
		super.caseTOperMod(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepAssign(TSepAssign node) {
		// TODO Auto-generated method stub
		super.caseTSepAssign(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTIdentifier(TIdentifier node) {
		// TODO Auto-generated method stub
		super.caseTIdentifier(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyInt(TKeyInt node) {
		// TODO Auto-generated method stub
		super.caseTKeyInt(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyChar(TKeyChar node) {
		// TODO Auto-generated method stub
		super.caseTKeyChar(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyNothing(TKeyNothing node) {
		// TODO Auto-generated method stub
		super.caseTKeyNothing(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepLbrack(TSepLbrack node) {
		// TODO Auto-generated method stub
		super.caseTSepLbrack(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepRbrack(TSepRbrack node) {
		// TODO Auto-generated method stub
		super.caseTSepRbrack(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepLpar(TSepLpar node) {
		// TODO Auto-generated method stub
		super.caseTSepLpar(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepRpar(TSepRpar node) {
		// TODO Auto-generated method stub
		super.caseTSepRpar(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepLbrace(TSepLbrace node) {
		// TODO Auto-generated method stub
		super.caseTSepLbrace(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTSepRbrace(TSepRbrace node) {
		// TODO Auto-generated method stub
		super.caseTSepRbrace(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyIf(TKeyIf node) {
		// TODO Auto-generated method stub
		super.caseTKeyIf(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyThen(TKeyThen node) {
		// TODO Auto-generated method stub
		super.caseTKeyThen(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyElse(TKeyElse node) {
		// TODO Auto-generated method stub
		super.caseTKeyElse(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyWhile(TKeyWhile node) {
		// TODO Auto-generated method stub
		super.caseTKeyWhile(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyDo(TKeyDo node) {
		// TODO Auto-generated method stub
		super.caseTKeyDo(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperOr(TOperOr node) {
		// TODO Auto-generated method stub
		super.caseTOperOr(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperAnd(TOperAnd node) {
		// TODO Auto-generated method stub
		super.caseTOperAnd(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperNot(TOperNot node) {
		// TODO Auto-generated method stub
		super.caseTOperNot(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperEq(TOperEq node) {
		// TODO Auto-generated method stub
		super.caseTOperEq(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperNe(TOperNe node) {
		// TODO Auto-generated method stub
		super.caseTOperNe(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperGt(TOperGt node) {
		// TODO Auto-generated method stub
		super.caseTOperGt(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperLt(TOperLt node) {
		// TODO Auto-generated method stub
		super.caseTOperLt(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperGe(TOperGe node) {
		// TODO Auto-generated method stub
		super.caseTOperGe(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTOperLe(TOperLe node) {
		// TODO Auto-generated method stub
		super.caseTOperLe(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyFun(TKeyFun node) {
		// TODO Auto-generated method stub
		super.caseTKeyFun(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyVar(TKeyVar node) {
		// TODO Auto-generated method stub
		super.caseTKeyVar(node);

		addNode(node, node.getText());
	}

	@Override
	public void caseTKeyRef(TKeyRef node) {
		// TODO Auto-generated method stub
		super.caseTKeyRef(node);

		addNode(node, node.getText());
	}
	
	@Override
	public void caseTKeyReturn(TKeyReturn node) {
		// TODO Auto-generated method stub
		super.caseTKeyReturn(node);
		
		addNode(node, node.getText());
	}
	
	@Override
	public void caseTSepColon(TSepColon node) {
		// TODO Auto-generated method stub
		super.caseTSepColon(node);
		
		addNode(node, node.getText());
	}
	
	@Override
	public void caseTSepComma(TSepComma node) {
		// TODO Auto-generated method stub
		super.caseTSepComma(node);
		
		addNode(node, node.getText());
	}
	
	@Override
	public void caseTSepSemi(TSepSemi node) {
		// TODO Auto-generated method stub
		super.caseTSepSemi(node);
		
		addNode(node, node.getText());
	}
}
