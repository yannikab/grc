using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Visitors.Cst
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAVarDef(AVarDef node)
		{
			helper.Pre();
		}

		public override void outAVarDef(AVarDef node)
		{
			Token keyVar = node.getKeyVar();
			Token id = node.getIdentifier();
			Token colon = node.getSepColon();
			Token semicolon = node.getSepSemi();

			HTypeVar hTypeVar = (HTypeVar)helper[helper.Count - 1];

			List<VarIdentifierT> identifiers = new List<VarIdentifierT>();

			identifiers.Add(new VarIdentifierT(id.getText(), id.getLine(), id.getPos()));

			for (int i = 0; i < helper.Count - 1; i++)
				identifiers.Add((VarIdentifierT)helper[i]);

			LocalVarDef localVarDef = new LocalVarDef(identifiers, hTypeVar, keyVar.getText(), colon.getText(), semicolon.getText(), keyVar.getLine(), keyVar.getPos());

			helper.Post(localVarDef);
		}

		public override void inAVarMore(AVarMore node)
		{
			helper.Pre();
		}

		public override void outAVarMore(AVarMore node)
		{
			Token id = node.getIdentifier();

			helper.Post(new VarIdentifierT(id.getText(), id.getLine(), id.getPos()));
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
