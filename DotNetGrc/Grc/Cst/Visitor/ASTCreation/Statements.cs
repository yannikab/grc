using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Stmt;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inASemicolonStmt(ASemicolonStmt node)
		{
			helper.Pre();
		}

		public override void outASemicolonStmt(ASemicolonStmt node)
		{
			Token t = node.getSepSemi();

			helper.Post(new StmtNoOpT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAAssignStmt(AAssignStmt node)
		{
			helper.Pre();
		}

		public override void outAAssignStmt(AAssignStmt node)
		{
			Token t1 = node.getSepAssign();
			Token t2 = node.getSepSemi();

			ExprLValBase lval = (ExprLValBase)helper[0];
			ExprBase expr = (ExprBase)helper[1];

			helper.Post(new StmtAssign(lval, expr, t1.getText(), t2.getText()));
		}

		public override void inABlockStmt(ABlockStmt node)
		{
			helper.Pre();
		}

		public override void outABlockStmt(ABlockStmt node)
		{
			Token t1 = node.getSepLbrace();
			Token t2 = node.getSepRbrace();

			List<StmtBase> stmts = new List<StmtBase>();

			for (int i = 0; i < helper.Count; i++)
				stmts.Add((StmtBase)helper[i]);

			StmtBlock stmtBlock = new StmtBlock(stmts, t1.getText(), t2.getText(), t1.getLine(), t1.getPos());

			helper.Post(stmtBlock);
		}

		public override void inAFunctionCallStmt(AFunctionCallStmt node)
		{
			helper.Pre();
		}

		public override void outAFunctionCallStmt(AFunctionCallStmt node)
		{
			Token t = node.getSepSemi();

			ExprFuncCall funCall = (ExprFuncCall)helper[0];

			helper.Post(new StmtFuncCall(funCall, t.getText()));
		}

		public override void inAReturnStmt(AReturnStmt node)
		{
			helper.Pre();
		}

		public override void outAReturnStmt(AReturnStmt node)
		{
			Token t1 = node.getKeyReturn();
			Token t2 = node.getSepSemi();

			ExprBase expr = helper.Count > 0 ? (ExprBase)helper[0] : null;

			helper.Post(new StmtReturn(expr, t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void inAThenIfStmt(AThenIfStmt node)
		{
			helper.Pre();
		}

		public override void outAThenIfStmt(AThenIfStmt node)
		{
			Token t1 = node.getKeyIf();
			Token t2 = node.getKeyThen();

			CondBase cond = (CondBase)helper[0];
			StmtBase stmt = (StmtBase)helper[1];

			helper.Post(new StmtIfThen(cond, stmt, t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void inAThenElseIfStmt(AThenElseIfStmt node)
		{
			helper.Pre();
		}

		public override void outAThenElseIfStmt(AThenElseIfStmt node)
		{
			Token t1 = node.getKeyIf();
			Token t2 = node.getKeyThen();
			Token t3 = node.getKeyElse();

			CondBase cond = (CondBase)helper[0];
			StmtBase stmtThen = (StmtBase)helper[1];
			StmtBase stmtElse = (StmtBase)helper[2];

			helper.Post(new StmtIfThenElse(cond, stmtThen, stmtElse, t1.getText(), t2.getText(), t3.getText(), t1.getLine(), t1.getPos()));
		}

		public override void inAIfStmtElse(AIfStmtElse node)
		{
			helper.Pre();
		}

		public override void outAIfStmtElse(AIfStmtElse node)
		{
			Token t1 = node.getKeyIf();
			Token t2 = node.getKeyThen();
			Token t3 = node.getKeyElse();

			CondBase cond = (CondBase)helper[0];
			StmtBase stmtThen = (StmtBase)helper[1];
			StmtBase stmtElse = (StmtBase)helper[2];

			helper.Post(new StmtIfThenElse(cond, stmtThen, stmtElse, t1.getText(), t2.getText(), t3.getText(), t1.getLine(), t1.getPos()));
		}

		public override void inAWhileStmt(AWhileStmt node)
		{
			helper.Pre();
		}

		public override void outAWhileStmt(AWhileStmt node)
		{
			Token t1 = node.getKeyWhile();
			Token t2 = node.getKeyDo();

			CondBase cond = (CondBase)helper[0];
			StmtBase stmt = (StmtBase)helper[1];

			helper.Post(new StmtWhileDo(cond, stmt, t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void inAWhileStmtElse(AWhileStmtElse node)
		{
			helper.Pre();
		}

		public override void outAWhileStmtElse(AWhileStmtElse node)
		{
			Token t1 = node.getKeyWhile();
			Token t2 = node.getKeyDo();

			CondBase cond = (CondBase)helper[0];
			StmtBase stmt = (StmtBase)helper[1];

			helper.Post(new StmtWhileDo(cond, stmt, t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}
	}
}
