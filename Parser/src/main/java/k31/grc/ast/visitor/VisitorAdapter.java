package k31.grc.ast.visitor;

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
import k31.grc.ast.node.helper.Ref;
import k31.grc.ast.node.helper.Root;
import k31.grc.ast.node.helper.Type;
import k31.grc.ast.node.helper.Val;
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

public class VisitorAdapter implements Visitor {

	@Override
	public void visit(Root n) {

	}

	@Override
	public void visit(ExprIntegerT n) {

	}

	@Override
	public void visit(ExprCharacterT n) {

	}

	@Override
	public void visit(LValueIdentifierT n) {

	}

	@Override
	public void visit(LValueStringT n) {

	}

	@Override
	public void visit(LValueIndexed n) {

	}

	@Override
	public void visit(ExprBinOpBase n) {

	}

	@Override
	public void visit(ExprPlus n) {

	}

	@Override
	public void visit(ExprMinus n) {

	}

	@Override
	public void visit(ExprFuncCall n) {

	}

	@Override
	public void visit(CondRelOpBase n) {

	}

	@Override
	public void visit(CondOr n) {

	}

	@Override
	public void visit(CondAnd n) {

	}

	@Override
	public void visit(CondNot n) {

	}

	@Override
	public void visit(StmtNoOpT n) {

	}

	@Override
	public void visit(StmtBlock n) {

	}

	@Override
	public void visit(StmtAssign n) {

	}

	@Override
	public void visit(StmtIfThen n) {

	}

	@Override
	public void visit(StmtIfThenElse n) {

	}

	@Override
	public void visit(StmtWhileDo n) {

	}

	@Override
	public void visit(StmtFuncCall n) {

	}

	@Override
	public void visit(StmtReturn n) {

	}

	@Override
	public void visit(Ref n) {

	}

	@Override
	public void visit(Val n) {

	}

	@Override
	public void visit(FParIdentifierT n) {

	}

	@Override
	public void visit(LocalVarDef n) {

	}

	@Override
	public void visit(VarIdentifierT n) {

	}

	@Override
	public void visit(Type n) {

	}

	@Override
	public void visit(LocalFuncDef n) {

	}

	@Override
	public void visit(LocalFuncDecl n) {

	}

	@Override
	public void visit(TypeDataBase n) {

	}

	@Override
	public void visit(TypeReturnNothingT n) {

	}

	@Override
	public void visit(DimEmptyT n) {

	}

	@Override
	public void visit(DimIntegerT n) {

	}

}
