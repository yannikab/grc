using k31.grc.cst.node;

namespace Grc.Cst.Visitor.GraphViz
{
	public class GraphVizTraversalTokens : GraphVizTraversal
	{
		public GraphVizTraversalTokens(GVNode root) : base(root)
		{
		}

		public override void caseTInteger(TInteger node)
		{
			base.caseTInteger(node);

			addNode(node, node.getText());
		}

		public override void caseTCharacter(TCharacter node)
		{
			base.caseTCharacter(node);

			addNode(node, node.getText());
		}

		public override void caseTString(TString node)
		{
			base.caseTString(node);

			addNode(node, node.getText());
		}

		public override void caseTOperPlus(TOperPlus node)
		{
			base.caseTOperPlus(node);

			addNode(node, node.getText());
		}

		public override void caseTOperMinus(TOperMinus node)
		{
			base.caseTOperMinus(node);

			addNode(node, node.getText());
		}

		public override void caseTOperMul(TOperMul node)
		{
			base.caseTOperMul(node);

			addNode(node, node.getText());
		}

		public override void caseTOperDiv(TOperDiv node)
		{
			base.caseTOperDiv(node);

			addNode(node, node.getText());
		}

		public override void caseTOperMod(TOperMod node)
		{
			base.caseTOperMod(node);

			addNode(node, node.getText());
		}

		public override void caseTSepAssign(TSepAssign node)
		{
			base.caseTSepAssign(node);

			addNode(node, node.getText());
		}

		public override void caseTIdentifier(TIdentifier node)
		{
			base.caseTIdentifier(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyInt(TKeyInt node)
		{
			base.caseTKeyInt(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyChar(TKeyChar node)
		{
			base.caseTKeyChar(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyNothing(TKeyNothing node)
		{
			base.caseTKeyNothing(node);

			addNode(node, node.getText());
		}

		public override void caseTSepLbrack(TSepLbrack node)
		{
			base.caseTSepLbrack(node);

			addNode(node, node.getText());
		}

		public override void caseTSepRbrack(TSepRbrack node)
		{
			base.caseTSepRbrack(node);

			addNode(node, node.getText());
		}

		public override void caseTSepLpar(TSepLpar node)
		{
			base.caseTSepLpar(node);

			addNode(node, node.getText());
		}

		public override void caseTSepRpar(TSepRpar node)
		{
			base.caseTSepRpar(node);

			addNode(node, node.getText());
		}

		public override void caseTSepLbrace(TSepLbrace node)
		{
			base.caseTSepLbrace(node);

			addNode(node, node.getText());
		}

		public override void caseTSepRbrace(TSepRbrace node)
		{
			base.caseTSepRbrace(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyIf(TKeyIf node)
		{
			base.caseTKeyIf(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyThen(TKeyThen node)
		{
			base.caseTKeyThen(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyElse(TKeyElse node)
		{
			base.caseTKeyElse(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyWhile(TKeyWhile node)
		{
			base.caseTKeyWhile(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyDo(TKeyDo node)
		{
			base.caseTKeyDo(node);

			addNode(node, node.getText());
		}

		public override void caseTOperOr(TOperOr node)
		{
			base.caseTOperOr(node);

			addNode(node, node.getText());
		}

		public override void caseTOperAnd(TOperAnd node)
		{
			base.caseTOperAnd(node);

			addNode(node, node.getText());
		}

		public override void caseTOperNot(TOperNot node)
		{
			base.caseTOperNot(node);

			addNode(node, node.getText());
		}

		public override void caseTOperEq(TOperEq node)
		{
			base.caseTOperEq(node);

			addNode(node, node.getText());
		}

		public override void caseTOperNe(TOperNe node)
		{
			base.caseTOperNe(node);

			addNode(node, node.getText());
		}

		public override void caseTOperGt(TOperGt node)
		{
			base.caseTOperGt(node);

			addNode(node, node.getText());
		}

		public override void caseTOperLt(TOperLt node)
		{
			base.caseTOperLt(node);

			addNode(node, node.getText());
		}

		public override void caseTOperGe(TOperGe node)
		{
			base.caseTOperGe(node);

			addNode(node, node.getText());
		}

		public override void caseTOperLe(TOperLe node)
		{
			base.caseTOperLe(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyFun(TKeyFun node)
		{
			base.caseTKeyFun(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyVar(TKeyVar node)
		{
			base.caseTKeyVar(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyRef(TKeyRef node)
		{
			base.caseTKeyRef(node);

			addNode(node, node.getText());
		}

		public override void caseTKeyReturn(TKeyReturn node)
		{
			base.caseTKeyReturn(node);

			addNode(node, node.getText());
		}

		public override void caseTSepColon(TSepColon node)
		{
			base.caseTSepColon(node);

			addNode(node, node.getText());
		}

		public override void caseTSepComma(TSepComma node)
		{
			base.caseTSepComma(node);

			addNode(node, node.getText());
		}

		public override void caseTSepSemi(TSepSemi node)
		{
			base.caseTSepSemi(node);

			addNode(node, node.getText());
		}
	}
}
