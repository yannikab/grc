package k31.grc.ast.visitor;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.node.aux.Type;
import k31.grc.ast.node.aux.Val;
import k31.grc.ast.node.aux.Ref;
import k31.grc.ast.node.aux.Root;
import k31.grc.ast.node.cond.CondAnd;
import k31.grc.ast.node.cond.CondNot;
import k31.grc.ast.node.cond.CondOr;
import k31.grc.ast.node.cond.CondRelOpBase;
import k31.grc.ast.node.expr.ExprBinOpBase;
import k31.grc.ast.node.expr.ExprCharacterT;
import k31.grc.ast.node.expr.ExprFuncCall;
import k31.grc.ast.node.expr.ExprIntegerT;
import k31.grc.ast.node.expr.ExprMinus;
import k31.grc.ast.node.expr.ExprPlus;
import k31.grc.ast.node.expr.LValueIdentifierT;
import k31.grc.ast.node.expr.LValueIndexed;
import k31.grc.ast.node.expr.LValueStringT;
import k31.grc.ast.node.func.FParIdentifierT;
import k31.grc.ast.node.func.LocalFuncDecl;
import k31.grc.ast.node.func.LocalFuncDef;
import k31.grc.ast.node.func.LocalVarDef;
import k31.grc.ast.node.func.VarIdentifierT;
import k31.grc.ast.node.stmt.StmtAssign;
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
import k31.grc.ast.node.type.TypeReturnNothingT;

public class PrintVisitor implements Visitor {

	void defaultAction(NodeBase n) {

		System.out.println(n.getText());

		for (NodeBase c : n.getChildren()) {
			c.accept(this);
		}
	}

	@Override
	public void visit(Root n) {

		defaultAction(n);
	}

	@Override
	public void visit(ExprIntegerT n) {

		defaultAction(n);
	}

	@Override
	public void visit(ExprBinOpBase n) {

		defaultAction(n);
	}

	@Override
	public void visit(CondRelOpBase n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtIfThen n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtWhileDo n) {

		defaultAction(n);

	}

	@Override
	public void visit(LocalFuncDecl n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtBlock n) {

		defaultAction(n);
	}

	@Override
	public void visit(ExprCharacterT n) {

		defaultAction(n);
	}

	@Override
	public void visit(ExprPlus n) {

		defaultAction(n);
	}

	@Override
	public void visit(ExprMinus n) {

		defaultAction(n);
	}

	@Override
	public void visit(CondOr n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtNoOpT n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtAssign n) {

		defaultAction(n);
	}

	@Override
	public void visit(CondAnd n) {

		defaultAction(n);
	}

	@Override
	public void visit(CondNot n) {

		defaultAction(n);
	}

	@Override
	public void visit(LValueIdentifierT n) {

		defaultAction(n);
	}

	@Override
	public void visit(VarIdentifierT n) {

		defaultAction(n);
	}

	@Override
	public void visit(FParIdentifierT n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtFuncCall n) {

		defaultAction(n);
	}

	@Override
	public void visit(LocalFuncDef n) {

		defaultAction(n);
	}

	@Override
	public void visit(Ref n) {

		defaultAction(n);
	}

	@Override
	public void visit(Val n) {

		defaultAction(n);
	}

	@Override
	public void visit(LocalVarDef n) {

		defaultAction(n);
	}

	@Override
	public void visit(LValueStringT n) {

		defaultAction(n);
	}

	@Override
	public void visit(LValueIndexed n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtIfThenElse n) {

		defaultAction(n);
	}

	@Override
	public void visit(StmtReturn n) {

		defaultAction(n);
	}

	@Override
	public void visit(ExprFuncCall n) {

		defaultAction(n);
	}

	@Override
	public void visit(TypeDataBase n) {

		defaultAction(n);
	}

	@Override
	public void visit(TypeReturnNothingT n) {

		defaultAction(n);
	}

	@Override
	public void visit(DimEmptyT n) {

		defaultAction(n);
	}

	@Override
	public void visit(DimIntegerT n) {

		defaultAction(n);
	}

	@Override
	public void visit(Type n) {

		defaultAction(n);
	}
}
