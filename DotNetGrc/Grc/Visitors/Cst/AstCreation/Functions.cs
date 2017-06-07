using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Nodes.Type;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Visitors.Cst
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAFparType(AFparType node)
		{
			helper.Pre();
		}

		public override void outAFparType(AFparType node)
		{
			TypeDataBase dataType = (TypeDataBase)helper[0];

			DimEmptyT dimEmpty = null;

			List<DimIntegerT> dims = new List<DimIntegerT>();

			if (helper.Count > 1)
			{
				int j = ((dimEmpty = helper[1] as DimEmptyT) == null) ? 0 : 1;

				for (int i = 1 + j; i < helper.Count; i++)
					dims.Add((DimIntegerT)helper[i]);
			}

			HTypePar hTypePar = new HTypePar(dataType, dimEmpty, dims);

			helper.Post(hTypePar);
		}

		public override void inAFparDef(AFparDef node)
		{
			helper.Pre();
		}

		public override void outAFparDef(AFparDef node)
		{
			Token keyRef = node.getKeyRef();
			Token id = node.getIdentifier();
			Token colon = node.getSepColon();

			bool byRef = keyRef != null;

			int line = (byRef ? keyRef : id).getLine();
			int pos = (byRef ? keyRef : id).getPos();

			List<ParIdentifierT> identifiers = new List<ParIdentifierT>();

			identifiers.Add(new ParIdentifierT(id.getText(), id.getLine(), id.getPos()));

			for (int i = 0; i < helper.Count - 1; i++)
				identifiers.Add((ParIdentifierT)helper[i]);

			HTypePar hTypePar = (HTypePar)helper[helper.Count - 1];

			HPar hPar = new HPar(identifiers, hTypePar, byRef ? keyRef.getText() : null, colon.getText(), line, pos);

			helper.Post(hPar);
		}

		public override void inAParMore(AParMore node)
		{
			helper.Pre();
		}

		public override void outAParMore(AParMore node)
		{
			Token id = node.getIdentifier();

			helper.Post(new ParIdentifierT(id.getText(), id.getLine(), id.getPos()));
		}

		public override void inAHeader(AHeader node)
		{
			helper.Pre();
		}

		public override void outAHeader(AHeader node)
		{
			Token keyFun = node.getKeyFun();
			Token id = node.getIdentifier();
			Token lpar = node.getSepLpar();
			Token rpar = node.getSepRpar();
			Token colon = node.getSepColon();

			List<HPar> hPars = new List<HPar>();

			for (int i = 0; i < helper.Count - 1; i++)
				hPars.Add((HPar)helper[i]);

			HTypeReturn hTypeReturn = (HTypeReturn)helper[helper.Count - 1];

			LocalFuncDecl localFuncDecl = new LocalFuncDecl(hPars, hTypeReturn, keyFun.getText(), id.getText(), lpar.getText(), rpar.getText(), colon.getText(), id.getLine(), id.getPos());

			helper.Post(localFuncDecl);
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
			helper.Pre();
		}

		public override void outAFuncDef(AFuncDef node)
		{
			LocalFuncDecl header = (LocalFuncDecl)helper[0];

			List<LocalBase> locals = new List<LocalBase>();

			for (int i = 1; i < helper.Count - 1; i++)
				locals.Add((LocalBase)helper[i]);

			StmtBlock stmtBlock = (StmtBlock)helper[helper.Count - 1];

			LocalFuncDef localFuncDef = new LocalFuncDef(header, locals, stmtBlock);

			helper.Post(localFuncDef);
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
