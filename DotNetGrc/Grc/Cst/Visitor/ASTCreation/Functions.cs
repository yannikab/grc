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
		public override void inAFparType(AFparType node)
		{
			defaultIn(node);

			PushNode(new HType());
		}

		public override void outAFparType(AFparType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFparDef(AFparDef node)
		{
			defaultIn(node);

			if (node.getKeyRef() != null)
				PushNode(new HRef());
			else
				PushNode(new HVal());

			PushNode(new FParIdentifierT(node.getIdentifier().getText()));
			PopNode();
		}

		public override void outAFparDef(AFparDef node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAParMore(AParMore node)
		{
			defaultIn(node);

			PushNode(new FParIdentifierT(node.getIdentifier().getText()));
		}

		public override void outAParMore(AParMore node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAHeader(AHeader node)
		{
			defaultIn(node);

			PushNode(new LocalFuncDecl(string.Format("{0}{1}{2}", node.getIdentifier().getText(), node.getSepLpar().getText(), node.getSepRpar().getText())));
		}

		public override void outAHeader(AHeader node)
		{
			defaultOut(node);

			LocalFuncDecl n = (LocalFuncDecl)GetNode();

			n.ProcessFuncDecl();

			PopNode();
		}

		public override void inAFuncParams(AFuncParams node)
		{
			defaultIn(node);
		}

		public override void outAFuncParams(AFuncParams node)
		{
			defaultOut(node);
		}

		public override void inAFparDefMore(AFparDefMore node)
		{
			defaultIn(node);
		}

		public override void outAFparDefMore(AFparDefMore node)
		{
			defaultOut(node);
		}

		public override void inAFuncDecl(AFuncDecl node)
		{
			defaultIn(node);
		}

		public override void outAFuncDecl(AFuncDecl node)
		{
			defaultOut(node);
		}

		public override void inAFuncDef(AFuncDef node)
		{
			defaultIn(node);

			PushNode(new LocalFuncDef());
		}

		public override void outAFuncDef(AFuncDef node)
		{
			defaultOut(node);

			LocalFuncDef n = (LocalFuncDef)GetNode();

			PopNode();

			if (n.Children.Count < 2)
				return;

			if (!(n.Children[0] is LocalFuncDecl))
				return;

			for (int i = 1; i < n.Children.Count - 1; i++)
				if (!(n.Children[i] is LocalBase))
					return;

			if (!(n.Children[n.Children.Count - 1] is StmtBlock))
				return;

			n.Header = (LocalFuncDecl)n.Children[0];

			for (int j = 1; j < n.Children.Count - 1; j++)
				n.AddLocal(n.Children[j] as LocalBase);

			n.Block = (StmtBlock)n.Children[n.Children.Count - 1];
		}

		public override void inAFuncLocalDef(AFuncLocalDef node)
		{
			defaultIn(node);
		}

		public override void outAFuncLocalDef(AFuncLocalDef node)
		{
			defaultOut(node);
		}

		public override void inAFuncDeclLocalDef(AFuncDeclLocalDef node)
		{
			defaultIn(node);
		}

		public override void outAFuncDeclLocalDef(AFuncDeclLocalDef node)
		{
			defaultOut(node);
		}
	}
}
