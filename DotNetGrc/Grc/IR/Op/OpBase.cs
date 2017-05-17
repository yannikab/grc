using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.IR.Exceptions;

namespace Grc.IR.Op
{
	public abstract class OpBase
	{
		public static OpBase GetOp(CondRelOpBase n)
		{
			if (n is CondEq)
				return OpEq.Instance;
			else if (n is CondNe)
				return OpNe.Instance;
			else if (n is CondGt)
				return OpGt.Instance;
			else if (n is CondLt)
				return OpLt.Instance;
			else if (n is CondGe)
				return OpGe.Instance;
			else if (n is CondLe)
				return OpLe.Instance;
			else throw new IRException("Invalid relational operator.");
		}

		public static OpBase GetOp(ExprBase n)
		{
			if (n is ExprAdd)
				return OpAdd.Instance;
			else if (n is ExprSub)
				return OpSub.Instance;
			else if (n is ExprMul)
				return OpMul.Instance;
			else if (n is ExprDiv)
				return OpDiv.Instance;
			else if (n is ExprMod)
				return OpMod.Instance;
			else if (n is ExprPlus)
				return OpAdd.Instance;
			else if (n is ExprMinus)
				return OpSub.Instance;

			else throw new IRException("Invalid binary operator.");
		}
	}
}
