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
		public override void inACharDataType(ACharDataType node)
		{
			defaultIn(node);

			PushNode(new TypeDataCharT(node.getKeyChar().getText()));
		}

		public override void outACharDataType(ACharDataType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAIntDataType(AIntDataType node)
		{
			defaultIn(node);

			PushNode(new TypeDataIntT(node.getKeyInt().getText()));
		}

		public override void outAIntDataType(AIntDataType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inADataReturnType(ADataReturnType node)
		{
			defaultIn(node);

			PushNode(new HType());
		}

		public override void outADataReturnType(ADataReturnType node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inANothingReturnType(ANothingReturnType node)
		{
			defaultIn(node);

			PushNode(new HType());

			PushNode(new TypeReturnNothingT((node.getKeyNothing().getText())));
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

			PushNode(new DimEmptyT(string.Format("{0}{1}", node.getSepLbrack().getText(), node.getSepRbrack().getText())));
		}

		public override void outAArrayNoDim(AArrayNoDim node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAArrayDim(AArrayDim node)
		{
			defaultIn(node);

			PushNode(new DimIntegerT(string.Format("{0}{1}{2}", node.getSepLbrack().getText(), node.getInteger().getText(), node.getSepRbrack().getText())));
		}

		public override void outAArrayDim(AArrayDim node)
		{
			defaultOut(node);

			PopNode();
		}

		public override void inAType(AType node)
		{
			defaultIn(node);

			PushNode(new HType());
		}

		public override void outAType(AType node)
		{
			defaultOut(node);

			PopNode();
		}
	}
}
