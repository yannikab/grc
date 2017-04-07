package k31.grc.ast.visitor;

import java.util.HashMap;
import java.util.Map;
import java.util.Stack;

import k31.grc.ast.node.NodeBase;
import k31.grc.ast.node.Parameter;
import k31.grc.ast.node.Variable;
import k31.grc.ast.node.aux.Ref;
import k31.grc.ast.node.aux.Root;
import k31.grc.ast.node.aux.Type;
import k31.grc.ast.node.aux.Val;
import k31.grc.ast.node.cond.CondAnd;
import k31.grc.ast.node.cond.CondNot;
import k31.grc.ast.node.cond.CondOr;
import k31.grc.ast.node.cond.CondRelOpBase;
import k31.grc.ast.node.expr.ExprBase;
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
import k31.grc.ast.node.func.LocalBase;
import k31.grc.ast.node.func.LocalFuncDecl;
import k31.grc.ast.node.func.LocalFuncDef;
import k31.grc.ast.node.func.LocalVarDef;
import k31.grc.ast.node.func.VarIdentifierT;
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
import k31.grc.ast.node.type.TypeReturnNothingT;

public class GraphVizNodeDataVisitor extends VisitorAdapter {

	private Map<NodeBase, Integer> id = new HashMap<>();

	private int nextId = 0;

	private Stack<NodeBase> stack = new Stack<>();

	private void addString(String s) {

		int i = nextId++;

		System.out.println("\t" + gvName(i) + " ;");
		System.out.println("\t" + gvName(i) + " [label=\"" + gvData(s) + "\"] ;");

		if (!stack.isEmpty())
			System.out.println("\t" + gvName(id.get(stack.peek())) + " -- " + gvName(i));
	}

	private String gvName(int id) {

		return String.format("n%1$04d", id);
	}

	private String gvData(String text) {

		return text.replace("\\", "\\\\").replace("\"", "\\\"").replace("[", "\\[").replace("]", "\\]");
	}

	private void pre(NodeBase n) {

		if (!id.containsKey(n))
			id.put(n, nextId++);

		System.out.println("\t" + gvName(id.get(n)) + " ;");
		System.out.println("\t" + gvName(id.get(n)) + " [label=\"" + gvData(n.toString()) + "\"] ;");

		if (!stack.isEmpty())
			System.out.println("\t" + gvName(id.get(stack.peek())) + " -- " + gvName(id.get(n)));

		stack.push(n);
	}

	private void post(NodeBase n) {

		stack.pop();
	}

	@Override
	public void visit(Root n) {

		System.out.println("graph\n{");

		// pre(n);

		if (n.getChildren().size() == 1)
			n.getChildren().get(0).accept(this);

		// post(n);

		System.out.println("}");
	}

	@Override
	public void visit(ExprIntegerT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(ExprCharacterT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(LValueIdentifierT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(LValueStringT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(LValueIndexed n) {
		pre(n);

		n.getLval().accept(this);

		n.getExpr().accept(this);

		post(n);
	}

	@Override
	public void visit(ExprBinOpBase n) {
		pre(n);

		n.getLeft().accept(this);

		n.getRight().accept(this);

		post(n);
	}

	@Override
	public void visit(ExprPlus n) {
		pre(n);

		n.getExpr().accept(this);

		post(n);
	}

	@Override
	public void visit(ExprMinus n) {
		pre(n);

		n.getExpr().accept(this);

		post(n);
	}

	@Override
	public void visit(ExprFuncCall n) {
		pre(n);

		for (ExprBase e : n.getArgs())
			e.accept(this);

		post(n);
	}

	@Override
	public void visit(CondRelOpBase n) {
		pre(n);

		n.getLeft().accept(this);

		n.getRight().accept(this);

		post(n);
	}

	@Override
	public void visit(CondOr n) {
		pre(n);

		n.getLeft().accept(this);

		n.getRight().accept(this);

		post(n);
	}

	@Override
	public void visit(CondAnd n) {
		pre(n);

		n.getLeft().accept(this);

		n.getRight().accept(this);

		post(n);
	}

	@Override
	public void visit(CondNot n) {
		pre(n);

		n.getCond().accept(this);

		post(n);
	}

	@Override
	public void visit(StmtNoOpT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(StmtBlock n) {
		pre(n);

		for (StmtBase s : n.getStmts())
			s.accept(this);

		post(n);
	}

	@Override
	public void visit(StmtAssign n) {
		pre(n);

		n.getLval().accept(this);

		n.getExpr().accept(this);

		post(n);
	}

	@Override
	public void visit(StmtIfThen n) {
		pre(n);

		n.getCond().accept(this);

		n.getStmt().accept(this);

		post(n);
	}

	@Override
	public void visit(StmtIfThenElse n) {
		pre(n);

		n.getCond().accept(this);

		n.getStmtThen().accept(this);

		n.getStmtElse().accept(this);

		post(n);
	}

	@Override
	public void visit(StmtWhileDo n) {
		pre(n);

		n.getCond().accept(this);

		n.getStmt().accept(this);

		post(n);
	}

	@Override
	public void visit(StmtFuncCall n) {
		pre(n);

		for (ExprBase e : n.getArgs())
			e.accept(this);

		post(n);
	}

	@Override
	public void visit(StmtReturn n) {
		pre(n);

		if (n.getExpr() != null)
			n.getExpr().accept(this);

		post(n);
	}

	@Override
	public void visit(Ref n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(Val n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(FParIdentifierT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(LocalVarDef n) {
		pre(n);

		if (n.getParent() instanceof LocalFuncDef)
			for (Variable v : ((LocalFuncDef) n.getParent()).getVars())
				addString(v.toString());

		post(n);
	}

	@Override
	public void visit(VarIdentifierT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(Type n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(LocalFuncDef n) {
		pre(n);

		n.getHeader().accept(this);

		if (n.getVarDef() != null)
			n.getVarDef().accept(this);

		for (LocalBase l : n.getFuncDecls())
			l.accept(this);

		for (LocalBase l : n.getFuncDefs())
			l.accept(this);

		n.getBlock().accept(this);

		post(n);
	}

	@Override
	public void visit(LocalFuncDecl n) {
		pre(n);

		for (Parameter p : n.getParams())
			addString(p.toString());

		n.getReturnType().accept(this);

		post(n);
	}

	@Override
	public void visit(TypeDataBase n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(TypeReturnNothingT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(DimEmptyT n) {
		pre(n);
		post(n);
	}

	@Override
	public void visit(DimIntegerT n) {
		pre(n);
		post(n);
	}
}
