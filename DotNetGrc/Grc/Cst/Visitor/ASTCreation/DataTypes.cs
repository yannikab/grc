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
			helper.Pre();
		}

		public override void outACharDataType(ACharDataType node)
		{
			Token t = node.getKeyChar();

			helper.Post(new TypeDataCharT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inAIntDataType(AIntDataType node)
		{
			helper.Pre();
		}

		public override void outAIntDataType(AIntDataType node)
		{
			Token t = node.getKeyInt();

			helper.Post(new TypeDataIntT(t.getText(), t.getLine(), t.getPos()));
		}

		public override void inADataReturnType(ADataReturnType node)
		{
			helper.Pre();
		}

		public override void outADataReturnType(ADataReturnType node)
		{
			TypeReturnBase returnType = (TypeReturnBase)helper[0];

			helper.Post(new HTypeReturn(returnType));
		}

		public override void inANothingReturnType(ANothingReturnType node)
		{
			helper.Pre();
		}

		public override void outANothingReturnType(ANothingReturnType node)
		{
			Token t = node.getKeyNothing();

			helper.Post(new HTypeReturn(new TypeReturnNothingT(t.getText(), t.getLine(), t.getPos())));
		}

		public override void inAArrayNoDim(AArrayNoDim node)
		{
			helper.Pre();
		}

		public override void outAArrayNoDim(AArrayNoDim node)
		{
			Token t1 = node.getSepLbrack();
			Token t2 = node.getSepRbrack();

			helper.Post(new DimEmptyT(t1.getText(), t2.getText(), t1.getLine(), t2.getPos()));
		}

		public override void inAArrayDim(AArrayDim node)
		{
			helper.Pre();
		}

		public override void outAArrayDim(AArrayDim node)
		{
			Token t1 = node.getInteger();
			Token t2 = node.getSepLbrack();
			Token t3 = node.getSepRbrack();

			helper.Post(new DimIntegerT(t1.getText(), t2.getText(), t3.getText(), t2.getLine(), t2.getPos()));
		}

		public override void inAType(AType node)
		{
			helper.Pre();
		}

		public override void outAType(AType node)
		{
			TypeDataBase dataType = (TypeDataBase)helper[0];

			List<DimIntegerT> dims = new List<DimIntegerT>();

			for (int i = 1; i < helper.Count; i++)
				dims.Add((DimIntegerT)helper[i]);

			helper.Post(new HTypeVar(dataType, dims));
		}
	}
}
