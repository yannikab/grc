package k31.grc.ast.visitor;

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

public interface Visitor {

	void visit(Root n);

	void visit(ExprIntegerT n);

	void visit(ExprCharacterT n);

	void visit(LValueIdentifierT n);

	void visit(LValueStringT n);

	void visit(LValueIndexed n);

	void visit(ExprBinOpBase n);

	void visit(ExprPlus n);

	void visit(ExprMinus n);

	void visit(ExprFuncCall n);

	void visit(CondRelOpBase n);

	void visit(CondOr n);

	void visit(CondAnd n);

	void visit(CondNot n);

	void visit(StmtNoOpT n);

	void visit(StmtBlock n);

	void visit(StmtAssign n);

	void visit(StmtIfThen n);

	void visit(StmtIfThenElse n);

	void visit(StmtWhileDo n);

	void visit(StmtFuncCall n);

	void visit(StmtReturn n);

	void visit(Ref n);

	void visit(Val n);

	void visit(FParIdentifierT n);

	void visit(LocalVarDef n);

	void visit(VarIdentifierT n);
	
	void visit(Type n);
	
	void visit(LocalFuncDef n);

	void visit(LocalFuncDecl n);

	void visit(TypeDataBase n);

	void visit(TypeReturnNothingT n);

	void visit(DimEmptyT n);

	void visit(DimIntegerT n);
}
