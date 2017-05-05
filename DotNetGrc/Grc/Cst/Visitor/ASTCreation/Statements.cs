using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Stmt;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inASemicolonStmt(ASemicolonStmt node)
		{
			defaultIn(node);

			Token t = node.getSepSemi();

			PushNode(new StmtNoOpT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outASemicolonStmt(ASemicolonStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAAssignStmt(AAssignStmt node)
		{
			defaultIn(node);

			Token t1 = node.getSepAssign();
			Token t2 = node.getSepSemi();

			PushNode(new StmtAssign(t1.getText(), t2.getText()));
		}

		public override void outAAssignStmt(AAssignStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inABlockStmt(ABlockStmt node)
		{
			defaultIn(node);

			Token t1 = node.getSepLbrace();
			Token t2 = node.getSepRbrace();

			PushNode(new StmtBlock(t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outABlockStmt(ABlockStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFunctionCallStmt(AFunctionCallStmt node)
		{
			defaultIn(node);

			Token t = node.getSepSemi();

			PushNode(new StmtFuncCall(t.getText()));
		}

		public override void outAFunctionCallStmt(AFunctionCallStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAReturnStmt(AReturnStmt node)
		{
			defaultIn(node);

			Token t1 = node.getKeyReturn();
			Token t2 = node.getSepSemi();

			PushNode(new StmtReturn(t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outAReturnStmt(AReturnStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAThenIfStmt(AThenIfStmt node)
		{
			defaultIn(node);

			Token t1 = node.getKeyIf();
			Token t2 = node.getKeyThen();

			PushNode(new StmtIfThen(t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outAThenIfStmt(AThenIfStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAThenElseIfStmt(AThenElseIfStmt node)
		{
			defaultIn(node);

			Token t1 = node.getKeyIf();
			Token t2 = node.getKeyThen();
			Token t3 = node.getKeyElse();

			PushNode(new StmtIfThenElse(t1.getText(), t2.getText(), t3.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outAThenElseIfStmt(AThenElseIfStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIfStmtElse(AIfStmtElse node)
		{
			defaultIn(node);

			Token t1 = node.getKeyIf();
			Token t2 = node.getKeyThen();
			Token t3 = node.getKeyElse();

			PushNode(new StmtIfThenElse(t1.getText(), t2.getText(), t3.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outAIfStmtElse(AIfStmtElse node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAWhileStmt(AWhileStmt node)
		{
			defaultIn(node);

			Token t1 = node.getKeyWhile();
			Token t2 = node.getKeyDo();

			PushNode(new StmtIfThen(t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outAWhileStmt(AWhileStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAWhileStmtElse(AWhileStmtElse node)
		{
			defaultIn(node);

			Token t1 = node.getKeyWhile();
			Token t2 = node.getKeyDo();

			PushNode(new StmtIfThen(t1.getText(), t2.getText(), t1.getLine(), t1.getPos()));
		}

		public override void outAWhileStmtElse(AWhileStmtElse node)
		{
			defaultOut(node);

			PopNode();
		}
	}
}
