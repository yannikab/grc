using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Cond;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Stmt;
using Grc.Quads;
using Grc.Quads.Addr;
using Grc.Quads.Op;
using Grc.Types;
using Grc.Visitors.Ast;

namespace Grc.Visitors.Tac
{
	public class TacVisitor : DepthFirstVisitor
	{
		private ExprLValBase indexed;
		private int noIndexDims;

		public override void Pre(LocalFuncDef n)
		{
			n.AddQuad(Quad.GenQuad(OpUnit.Instance, new AddrFunc(n.Header.Name), AddrEmpty.Instance, AddrEmpty.Instance));
		}

		public override void Post(LocalFuncDef n)
		{
			if (n.Block.Stmts.Count > 0)
				n.Block.Stmts[n.Block.Stmts.Count - 1].NextList.BackPatch(Quad.NextQuad.Addr);

			n.AddQuad(Quad.GenQuad(OpEndu.Instance, new AddrFunc(n.Header.Name), AddrEmpty.Instance, AddrEmpty.Instance));
		}

		public override void Post(ExprIntegerT n)
		{
			n.Addr = new AddrInt(int.Parse(n.Integer));
		}

		public override void Post(ExprCharacterT n)
		{
			n.Addr = new AddrChar(n.Character);
		}

		public override void Post(ExprBinOpBase n)
		{
			AddrTmp result = new AddrTmp(n.Type, false);

			n.AddQuad(Quad.GenQuad(n.GetOp(), n.Left.Addr, n.Right.Addr, result));

			n.Addr = result;
		}

		public override void Post(ExprPlus n)
		{
			AddrTmp result = new AddrTmp(n.Type, false);

			n.Addr = result;
		}

		public override void Post(ExprMinus n)
		{
			AddrTmp result = new AddrTmp(n.Type, false);

			n.AddQuad(Quad.GenQuad(n.GetOp(), new AddrInt(0), n.Expr.Addr, result));

			n.Addr = result;
		}

		public override void Post(ExprLValIdentifierT n)
		{
			if (n.IsPar)
				n.Addr = new AddrArg(n.Name, n.Type, n.IsParByRef);
			else
				n.Addr = new AddrLoc(n.Name, n.Type, n.Type is TypeIndexed);
		}

		public override void Post(ExprLValStringT n)
		{
			n.Addr = new AddrString(n.Text);
		}

		public override void Post(ExprFuncCall n)
		{
			Stack<AddrBase> passingModes = new Stack<AddrBase>();

			TypeBase current = n.TypeFrom;

			while (current is TypeProduct)
			{
				passingModes.Push((current as TypeProduct).Right.ByRef ? (AddrBase)AddrRef.Instance : (AddrBase)AddrVal.Instance);

				current = (current as TypeProduct).Left;
			}

			passingModes.Push(current.ByRef ? (AddrBase)AddrRef.Instance : (AddrBase)AddrVal.Instance);

			foreach (ExprBase e in n.Args)
				n.AddQuad(Quad.GenQuad(new OpParArg(), e.Addr, passingModes.Pop(), AddrEmpty.Instance));

			OpParRet opParRet = null;

			if (!(n.Type.Equals(TypeNothing.Instance)))
			{
				AddrTmp value = new AddrTmp(n.Type, false);

				opParRet = new OpParRet();

				n.AddQuad(Quad.GenQuad(opParRet, AddrRet.Instance, value, AddrEmpty.Instance));

				n.Addr = value;
			}

			n.AddQuad(Quad.GenQuad(opParRet != null ? new OpCall(opParRet) : new OpCall(), AddrEmpty.Instance, AddrEmpty.Instance, new AddrFunc(n.Name)));
		}

		public override void In(CondAnd n)
		{
			n.Left.TrueList.BackPatch(Quad.NextQuad.Addr);
		}

		public override void Post(CondAnd n)
		{
			n.TrueList = n.Right.TrueList;

			n.FalseList = n.Left.FalseList.Merge(n.Right.FalseList);
		}

		public override void In(CondOr n)
		{
			n.Left.FalseList.BackPatch(Quad.NextQuad.Addr);
		}

		public override void Post(CondOr n)
		{
			n.TrueList = n.Left.TrueList.Merge(n.Right.TrueList);

			n.FalseList = n.Right.FalseList;
		}

		public override void Post(CondNot n)
		{
			n.TrueList = n.Cond.FalseList;

			n.FalseList = n.Cond.TrueList;
		}

		public override void Post(CondRelOpBase n)
		{
			n.TrueList = QuadList.Make(Quad.NextQuad);

			n.AddQuad(Quad.GenQuad(n.GetOp(), n.Left.Addr, n.Right.Addr, AddrStar.Instance));

			n.FalseList = QuadList.Make(Quad.NextQuad);

			n.AddQuad(Quad.GenQuad(new OpGoto(), AddrEmpty.Instance, AddrEmpty.Instance, AddrStar.Instance));
		}

		public override void Post(StmtNoOpT n)
		{
			n.NextList = QuadList.Empty();
		}

		public override void In(StmtIfThen n)
		{
			n.Cond.TrueList.BackPatch(Quad.NextQuad.Addr);
		}

		public override void Post(StmtIfThen n)
		{
			n.NextList = n.Cond.FalseList.Merge(n.Stmt.NextList);
		}

		public override void InCondThen(StmtIfThenElse n)
		{
			n.Cond.TrueList.BackPatch(Quad.NextQuad.Addr);
		}

		public override void InThenElse(StmtIfThenElse n)
		{
			n.Temp = QuadList.Make(Quad.NextQuad);

			n.AddQuad(Quad.GenQuad(new OpGoto(), AddrEmpty.Instance, AddrEmpty.Instance, AddrStar.Instance));

			n.Cond.FalseList.BackPatch(Quad.NextQuad.Addr);
		}

		public override void Post(StmtIfThenElse n)
		{
			n.NextList = n.Temp.Merge(n.StmtThen.NextList).Merge(n.StmtElse.NextList);
		}

		public override void Pre(StmtWhileDo n)
		{
			n.Temp = Quad.NextQuad;
		}

		public override void In(StmtWhileDo n)
		{
			n.Cond.TrueList.BackPatch(Quad.NextQuad.Addr);
		}

		public override void Post(StmtWhileDo n)
		{
			n.Stmt.NextList.BackPatch(n.Temp.Addr);

			n.AddQuad(Quad.GenQuad(new OpGoto(), AddrEmpty.Instance, AddrEmpty.Instance, n.Temp.Addr));

			n.NextList = n.Cond.FalseList;
		}

		public override void Visit(StmtBlock n)
		{
			List<Quad> l = QuadList.Empty();

			foreach (StmtBase s in n.Stmts)
			{
				l.BackPatch(Quad.NextQuad.Addr);

				s.Accept(this);

				l = s.NextList;
			}

			n.NextList = l;
		}

		public override void Post(StmtAssign n)
		{
			n.AddQuad(Quad.GenQuad(new OpAssign(), n.Expr.Addr, AddrEmpty.Instance, n.Lval.Addr));

			n.NextList = QuadList.Empty();
		}

		public override void Post(StmtFuncCall n)
		{
			n.NextList = QuadList.Empty();
		}

		public override void Post(StmtReturn n)
		{
			if (n.Expr != null)
				n.AddQuad(Quad.GenQuad(new OpAssign(), n.Expr.Addr, AddrEmpty.Instance, AddrRetVal.Instance));

			n.AddQuad(Quad.GenQuad(new OpRet(), AddrEmpty.Instance, AddrEmpty.Instance, AddrEmpty.Instance));

			n.NextList = QuadList.Empty();
		}

		public override void Post(ExprLValIndexed n)
		{
			if (n.Lval is ExprLValIndexed)
			{
				AddrTmp temp = new AddrTmp(n.Expr.Type, false);

				AddrTmp index = new AddrTmp(n.Expr.Type, false);

				n.AddQuad(Quad.GenQuad(new OpMul(), n.Lval.Addr, new AddrInt((n.Lval.Type as TypeIndexed).Dim), temp));

				n.AddQuad(Quad.GenQuad(new OpAdd(), temp, n.Expr.Addr, index));

				n.Addr = index;

				noIndexDims--;
			}
			else
			{
				this.indexed = n.Lval;

				ExprLValIdentifierT id = this.indexed as ExprLValIdentifierT;

				if (id != null)
					noIndexDims = (id.Type as TypeIndexed).TotalDims - 1;

				AddrTmp index = new AddrTmp(n.Expr.Type, false);

				n.AddQuad(Quad.GenQuad(new OpAssign(), n.Expr.Addr, AddrEmpty.Instance, index));

				n.Addr = index;
			}

			if (!n.ParentIndexed)
			{
				if (indexed is ExprLValIdentifierT)
				{
					ExprLValIdentifierT id = (ExprLValIdentifierT)indexed;

					for (int i = noIndexDims; i > 0; i--)
					{
						AddrTmp temp = new AddrTmp(n.Expr.Type, false);

						TypeIndexed typeIndexed = (TypeIndexed)id.Type;

						int dim = typeIndexed.GetDim(typeIndexed.TotalDims - i);

						n.AddQuad(Quad.GenQuad(new OpMul(), n.Addr, new AddrInt(dim), temp));

						n.Addr = temp;
					}

					AddrTmp addrElem = new AddrTmp(n.Type, true);

					if (id.IsPar)
						n.AddQuad(Quad.GenQuad(new OpArray(), new AddrArg(id.Name, id.Type, id.IsParByRef), n.Addr, addrElem));
					else
						n.AddQuad(Quad.GenQuad(new OpArray(), new AddrLoc(id.Name, id.Type, id.Type is TypeIndexed), n.Addr, addrElem));

					n.Addr = new AddrArray(addrElem);
				}
				else if (indexed is ExprLValStringT)
				{
					ExprLValStringT str = (ExprLValStringT)indexed;

					AddrTmp addrElem = new AddrTmp(n.Type, true);

					AddrString addrString = new AddrString(str.Text);

					n.AddQuad(Quad.GenQuad(new OpArray(), addrString, n.Addr, addrElem));

					n.Addr = new AddrArray(addrElem);
				}

				this.indexed = null;
			}
		}
	}
}
