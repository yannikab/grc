using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Type;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Cst.Visitor.ASTCreation
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inACharDataType(ACharDataType node)
		{
			defaultIn(node);

			Token t = node.getKeyChar();

			PushNode(new TypeDataCharT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outACharDataType(ACharDataType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIntDataType(AIntDataType node)
		{
			defaultIn(node);

			Token t = node.getKeyInt();

			PushNode(new TypeDataIntT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void outAIntDataType(AIntDataType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inADataReturnType(ADataReturnType node)
		{
			defaultIn(node);

			PushNode(new HTypeReturn());
		}

		public override void outADataReturnType(ADataReturnType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inANothingReturnType(ANothingReturnType node)
		{
			defaultIn(node);

			PushNode(new HTypeReturn());

			Token t = node.getKeyNothing();

			PushNode(new TypeReturnNothingT(t.getText(), t.getLine(), t.getPos()));
			PopNode();
		}

		public override void outANothingReturnType(ANothingReturnType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAArrayNoDim(AArrayNoDim node)
		{
			defaultIn(node);

			Token t1 = node.getSepLbrack();
			Token t2 = node.getSepRbrack();

			PushNode(new DimEmptyT(t1.getText(), t2.getText(), t1.getLine(), t2.getPos()));
		}

		public override void outAArrayNoDim(AArrayNoDim node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAArrayDim(AArrayDim node)
		{
			defaultIn(node);

			Token t1 = node.getInteger();
			Token t2 = node.getSepLbrack();
			Token t3 = node.getSepRbrack();

			PushNode(new DimIntegerT(t1.getText(), t2.getText(), t3.getText(), t2.getLine(), t2.getPos()));
		}

		public override void outAArrayDim(AArrayDim node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAType(AType node)
		{
			defaultIn(node);

			PushNode(new HTypeVar());
		}

		public override void outAType(AType node)
		{
			defaultOut(node);

			PopNode();
		}
	}
}
