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

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAVarDef(AVarDef node)
		{
			defaultIn(node);

			Token keyVar = node.getKeyVar();
			Token id = node.getIdentifier();
			Token colon = node.getSepColon();
			Token semicolon = node.getSepSemi();

			PushNode(new LocalVarDef(keyVar.getText(), colon.getText(), semicolon.getText(), keyVar.getLine(), keyVar.getPos()));

			PushNode(new VarIdentifierT(id.getText(), id.getLine(), id.getPos()));
			PopNode();
		}

		public override void outAVarDef(AVarDef node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAVarMore(AVarMore node)
		{
			defaultIn(node);

			Token id = node.getIdentifier();

			PushNode(new VarIdentifierT(id.getText(), id.getLine(), id.getPos()));
		}

		public override void outAVarMore(AVarMore node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAVarLocalDef(AVarLocalDef node)
		{
			defaultIn(node);
		}

		public override void outAVarLocalDef(AVarLocalDef node)
		{
			defaultOut(node);
		}
	}
}
