using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAFparType(AFparType node)
		{
			defaultIn(node);

			PushNode(new HTypePar());
		}

		public override void outAFparType(AFparType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAFparDef(AFparDef node)
		{
			defaultIn(node);

			Token keyRef = node.getKeyRef();
			Token id = node.getIdentifier();
			Token colon = node.getSepColon();

			bool byRef = keyRef != null;

			int line = (byRef ? keyRef : id).getLine();
			int pos = (byRef ? keyRef : id).getPos();

			PushNode(new HPar(byRef ? keyRef.getText() : null, colon.getText(), line, pos));

			PushNode(new ParIdentifierT(id.getText(), id.getLine(), id.getPos()));
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

			Token id = node.getIdentifier();

			PushNode(new ParIdentifierT(id.getText(), id.getLine(), id.getPos()));
		}

		public override void outAParMore(AParMore node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAHeader(AHeader node)
		{
			defaultIn(node);

			Token keyFun = node.getKeyFun();
			Token id = node.getIdentifier();
			Token lpar = node.getSepLpar();
			Token rpar = node.getSepRpar();
			Token colon = node.getSepColon();

			PushNode(new LocalFuncDecl(keyFun.getText(), id.getText(), lpar.getText(), rpar.getText(), colon.getText(), id.getLine(), id.getPos()));
		}

		public override void outAHeader(AHeader node)
		{
			defaultOut(node);

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

			PopNode();
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
