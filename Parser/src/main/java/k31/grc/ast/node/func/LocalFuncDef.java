package k31.grc.ast.node.func;

import java.util.LinkedList;
import java.util.List;

import k31.grc.ast.node.Variable;
import k31.grc.ast.node.stmt.StmtBase;
import k31.grc.ast.node.stmt.StmtBlock;
import k31.grc.ast.visitor.Visitor;

public class LocalFuncDef extends LocalBase {

	private LocalFuncDecl header;
	private List<Variable> vars;
	private LocalVarDef varDef;
	private List<LocalFuncDecl> funcDecls;
	private List<LocalFuncDef> funcDefs;
	private StmtBlock block;

	public LocalFuncDecl getHeader() {
		return header;
	}

	public List<Variable> getVars() {
		return vars;
	}

	public LocalVarDef getVarDef() {
		return varDef;
	}

	public List<LocalFuncDecl> getFuncDecls() {
		return funcDecls;
	}

	public List<LocalFuncDef> getFuncDefs() {
		return funcDefs;
	}

	public StmtBlock getBlock() {
		return block;
	}

	public List<StmtBase> getStmts() {
		return this.block != null ? this.block.getStmts() : null;
	}

	public void setHeader(LocalFuncDecl header) {
		this.header = header;
	}

	public void setVarDef(LocalVarDef varDef) {
		this.varDef = varDef;
	}

	public void setBlock(StmtBlock block) {
		this.block = block;
	}

	public LocalFuncDef() {
		super("func-def");

		this.vars = new LinkedList<Variable>();
		this.funcDefs = new LinkedList<LocalFuncDef>();
		this.funcDecls = new LinkedList<LocalFuncDecl>();
	}

	@Override
	public void accept(Visitor v) {

		v.visit(this);
	}
}
