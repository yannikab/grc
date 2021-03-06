﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using System.Reflection.Emit;

namespace Grc.Nodes.Func
{
	public partial class LocalFuncDef : LocalBase
	{
		private List<ExprFuncCall> funcCalls = new List<ExprFuncCall>();

		public IEnumerable<ExprFuncCall> FuncCalls { get { return funcCalls; } }

		private int lifted;

		public int Lifted
		{
			get { return lifted; }
			set { lifted = value; }
		}

		public void AddFuncCallToParent(ExprFuncCall n)
		{
			if (Parent is LocalFuncDef)
				(Parent as LocalFuncDef).funcCalls.Add(n);
		}

		public void AddFuncCallToSelf(ExprFuncCall n)
		{
			funcCalls.Add(n);
		}

		public void ClearFuncCalls()
		{
			funcCalls.Clear();
		}

		public void Lift(LocalFuncDef lifter, LocalFuncDef liftable)
		{
			int i = locals.IndexOf(lifter);

			locals.Insert(i + 1, liftable);

			locals.Insert(i, liftable.header);

			liftable.Parent = this;

			lifted++;
		}

		public void ClearFuncLocals()
		{
			locals.RemoveAll(l => l is LocalFuncDecl || l is LocalFuncDef);
		}
	}
}
