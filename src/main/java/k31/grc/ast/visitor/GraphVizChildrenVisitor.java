package k31.grc.ast.visitor;

import java.util.HashMap;
import java.util.Map;

import k31.grc.ast.node.NodeBase;
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

public class GraphVizChildrenVisitor implements Visitor {

	private Map<NodeBase, Integer> id = new HashMap<>();

	private int nextId = 0;

	void printGraphViz(NodeBase n) {

		if (!id.containsKey(n))
			id.put(n, nextId++);

		System.out.println("\t" + gvName(id.get(n)) + " ;");
		System.out.println("\t" + gvName(id.get(n)) + " [label=\"" + gvData(n.getClass().getSimpleName() + "\n" + n.getText()) + "\"] ;");

		for (NodeBase c : n.getChildren()) {

			c.accept(this);

			System.out.println("\t" + gvName(id.get(n)) + " -- " + gvName(id.get(c)) + " ;");
		}
	}

	public String gvName(int id) {

		return String.format("n%1$04d", id);
	}

	public String gvData(String text) {

		return text.replace("\\", "\\\\").replace("\"", "\\\"").replace("[", "\\[").replace("]", "\\]");
	}

	@Override
	public void visit(Root n) {

		System.out.println("graph\n{");

		printGraphViz(n);

		System.out.println("}");
	}

	@Override
	public void visit(ExprIntegerT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(ExprBinOpBase n) {

		printGraphViz(n);
	}

	@Override
	public void visit(CondRelOpBase n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtIfThen n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtWhileDo n) {

		printGraphViz(n);
	}

	@Override
	public void visit(LocalFuncDecl n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtBlock n) {

		printGraphViz(n);
	}

	@Override
	public void visit(ExprCharacterT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(ExprPlus n) {

		printGraphViz(n);
	}

	@Override
	public void visit(ExprMinus n) {

		printGraphViz(n);
	}

	@Override
	public void visit(CondOr n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtNoOpT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtAssign n) {

		printGraphViz(n);
	}

	@Override
	public void visit(CondAnd n) {

		printGraphViz(n);
	}

	@Override
	public void visit(CondNot n) {

		printGraphViz(n);
	}

	@Override
	public void visit(LValueIdentifierT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(VarIdentifierT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(FParIdentifierT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtFuncCall n) {

		printGraphViz(n);
	}

	@Override
	public void visit(LocalFuncDef n) {

		printGraphViz(n);
	}

	@Override
	public void visit(Ref n) {

		printGraphViz(n);
	}

	@Override
	public void visit(Val n) {

		printGraphViz(n);
	}

	@Override
	public void visit(LocalVarDef n) {

		printGraphViz(n);
	}

	@Override
	public void visit(LValueStringT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(LValueIndexed n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtIfThenElse n) {

		printGraphViz(n);
	}

	@Override
	public void visit(StmtReturn n) {

		printGraphViz(n);
	}

	@Override
	public void visit(ExprFuncCall n) {

		printGraphViz(n);
	}

	@Override
	public void visit(TypeDataBase n) {

		printGraphViz(n);
	}

	@Override
	public void visit(TypeReturnNothingT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(DimEmptyT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(DimIntegerT n) {

		printGraphViz(n);
	}

	@Override
	public void visit(Type n) {

		printGraphViz(n);
	}
}
