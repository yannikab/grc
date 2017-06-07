using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Cond;
using Grc.Nodes.Expr;
using k31.grc.cst.analysis;
using k31.grc.cst.node;

namespace Grc.Visitors.Cst
{
	public partial class ASTCreationVisitor : DepthFirstAdapter
	{
		public override void inAOrOpExpressionL(AOrOpExpressionL node)
		{
			helper.Pre();
		}

		public override void outAOrOpExpressionL(AOrOpExpressionL node)
		{
			string operOr = node.getOperOr().getText();

			CondBase left = (CondBase)helper[0];
			CondBase right = (CondBase)helper[1];

			helper.Post(new CondOr(left, right, operOr));
		}

		public override void inAAndOpTermL(AAndOpTermL node)
		{
			helper.Pre();
		}

		public override void outAAndOpTermL(AAndOpTermL node)
		{
			string operAnd = node.getOperAnd().getText();

			CondBase left = (CondBase)helper[0];
			CondBase right = (CondBase)helper[1];

			helper.Post(new CondAnd(left, right, operAnd));
		}

		public override void inANotOpFactorL(ANotOpFactorL node)
		{
			helper.Pre();
		}

		public override void outANotOpFactorL(ANotOpFactorL node)
		{
			string operNot = node.getOperNot().getText();

			CondBase cond = (CondBase)helper[0];

			helper.Post(new CondNot(cond, operNot));
		}

		public override void inAEqualFactorL(AEqualFactorL node)
		{
			helper.Pre();
		}

		public override void outAEqualFactorL(AEqualFactorL node)
		{
			string operEq = node.getOperEq().getText();

			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new CondEq(left, right, operEq));
		}

		public override void inANotEqualFactorL(ANotEqualFactorL node)
		{
			helper.Pre();
		}

		public override void outANotEqualFactorL(ANotEqualFactorL node)
		{
			string operNe = node.getOperNe().getText();

			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new CondNe(left, right, operNe));
		}

		public override void inAGreaterThanFactorL(AGreaterThanFactorL node)
		{
			helper.Pre();
		}

		public override void outAGreaterThanFactorL(AGreaterThanFactorL node)
		{
			string operGt = node.getOperGt().getText();

			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new CondGt(left, right, operGt));
		}

		public override void inALessThanFactorL(ALessThanFactorL node)
		{
			helper.Pre();
		}

		public override void outALessThanFactorL(ALessThanFactorL node)
		{
			string operLt = node.getOperLt().getText();

			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new CondLt(left, right, operLt));
		}

		public override void inAGreaterEqualFactorL(AGreaterEqualFactorL node)
		{
			helper.Pre();
		}

		public override void outAGreaterEqualFactorL(AGreaterEqualFactorL node)
		{
			string operGe = node.getOperGe().getText();

			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new CondGe(left, right, operGe));
		}

		public override void inALessEqualFactorL(ALessEqualFactorL node)
		{
			helper.Pre();
		}

		public override void outALessEqualFactorL(ALessEqualFactorL node)
		{
			string operLe = node.getOperLe().getText();

			ExprBase left = (ExprBase)helper[0];
			ExprBase right = (ExprBase)helper[1];

			helper.Post(new CondLe(left, right, operLe));
		}
	}
}
