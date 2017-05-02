using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Node.Type;
using k31.grc.cst.analysis;
using k31.grc.cst.node;
using Grc.Cst.Visitor.ASTCreation.Exceptions;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inASemicolonStmt(ASemicolonStmt node)
		{
			defaultIn(node);

			PushNode(new StmtNoOpT(node.getSepSemi().getText()));
		}

		public override void outASemicolonStmt(ASemicolonStmt node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAAssignStmt(AAssignStmt node)
		{
			defaultIn(node);

			PushNode(new StmtAssign(node.getSepAssign().getText()));
		}

		public override void outAAssignStmt(AAssignStmt node)
		{
			defaultOut(node);

			StmtAssign n = (StmtAssign)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is ExprLValBase))
				return;

			if (!(n.Children[1] is ExprBase))
				return;

			n.Lval = (ExprLValBase)n.Children[0];
			n.Expr = (ExprBase)n.Children[1];
		}

		public override void inABlockStmt(ABlockStmt node)
		{
			defaultIn(node);

			PushNode(new StmtBlock(string.Format("{0} {1}", node.getSepLbrace().getText(), node.getSepRbrace().getText())));
		}

		public override void outABlockStmt(ABlockStmt node)
		{
			defaultOut(node);

			StmtBlock n = (StmtBlock)GetNode();
			PopNode();

			for (int i = 0; i < n.Children.Count; i++)
				if (!(n.Children[i] is StmtBase))
					throw new ASTCreationException();

			for (int i = 0; i < n.Children.Count; i++)
				n.AddStmt((StmtBase)n.Children[i]);
		}

		public override void inAFunctionCallStmt(AFunctionCallStmt node)
		{
			defaultIn(node);

			PushNode(new NodeBase());
		}

		public override void outAFunctionCallStmt(AFunctionCallStmt node)
		{
			defaultOut(node);

			NodeBase n = PopNode();

			if (n.Children.Count != 1)
				return;

			ExprFuncCall funcall = n.Children[0] as ExprFuncCall;

			if (funcall == null)
				return;

			n.ReplaceWith(new StmtFuncCall(funcall));
		}

		public override void inAReturnStmt(AReturnStmt node)
		{
			defaultIn(node);

			PushNode(new StmtReturn(node.getKeyReturn().getText()));
		}

		public override void outAReturnStmt(AReturnStmt node)
		{
			defaultOut(node);

			StmtReturn n = (StmtReturn)GetNode();
			PopNode();

			if (n.Children.Count > 1)
				return;

			if (n.Children.Count == 1 && !(n.Children[0] is ExprBase))
				return;

			n.Expr = n.Children.Count == 1 ? (ExprBase)n.Children[0] : null;
		}

		public override void inAThenIfStmt(AThenIfStmt node)
		{
			defaultIn(node);

			PushNode(new StmtIfThen(string.Format("{0}-{1}", node.getKeyIf().getText(), node.getKeyThen().getText())));
		}

		public override void outAThenIfStmt(AThenIfStmt node)
		{
			defaultOut(node);

			StmtIfThen n = (StmtIfThen)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			if (!(n.Children[1] is StmtBase))
				return;

			n.Cond = (CondBase)n.Children[0];
			n.Stmt = (StmtBase)n.Children[1];
		}

		private void outStmtIfThenElse()
		{
			StmtIfThenElse n = (StmtIfThenElse)GetNode();
			PopNode();

			if (n.Children.Count != 3)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			if (!(n.Children[1] is StmtBase && n.Children[2] is StmtBase))
				return;

			n.Cond = (CondBase)n.Children[0];
			n.StmtThen = (StmtBase)n.Children[1];
			n.StmtElse = (StmtBase)n.Children[2];
		}

		public override void inAThenElseIfStmt(AThenElseIfStmt node)
		{
			defaultIn(node);

			PushNode(new StmtIfThenElse(string.Format("{0}-{1}-{2}", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText())));
		}

		public override void outAThenElseIfStmt(AThenElseIfStmt node)
		{
			defaultOut(node);

			outStmtIfThenElse();
		}

		public override void inAIfStmtElse(AIfStmtElse node)
		{
			defaultIn(node);

			PushNode(new StmtIfThenElse(string.Format("{0}-{1}-{2}", node.getKeyIf().getText(), node.getKeyThen().getText(), node.getKeyElse().getText())));
		}

		public override void outAIfStmtElse(AIfStmtElse node)
		{
			defaultOut(node);

			outStmtIfThenElse();
		}

		private void outStmtWhileDo()
		{
			StmtWhileDo n = (StmtWhileDo)GetNode();
			PopNode();

			if (n.Children.Count != 2)
				return;

			if (!(n.Children[0] is CondBase))
				return;

			if (!(n.Children[1] is StmtBase))
				return;

			n.Cond = (CondBase)n.Children[0];
			n.Stmt = (StmtBase)n.Children[1];
		}

		public override void inAWhileStmt(AWhileStmt node)
		{
			defaultIn(node);

			PushNode(new StmtWhileDo(string.Format("{0}-{1}", node.getKeyWhile().getText(), node.getKeyDo().getText())));
		}

		public override void outAWhileStmt(AWhileStmt node)
		{
			defaultOut(node);

			outStmtWhileDo();
		}

		public override void inAWhileStmtElse(AWhileStmtElse node)
		{
			defaultIn(node);

			PushNode(new StmtWhileDo(string.Format("{0}-{1}", node.getKeyWhile().getText(), node.getKeyDo().getText())));
		}

		public override void outAWhileStmtElse(AWhileStmtElse node)
		{
			defaultOut(node);

			outStmtWhileDo();
		}
	}
}
