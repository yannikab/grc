using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Visitor;

namespace Grc.Cil.Visitor
{
	class LLBoomVisitor : DepthFirstVisitor
	{
		private bool madeChanges;

		public bool MadeChanges { get { return madeChanges; } }

		public override void Pre(Root n)
		{
			madeChanges = false;

			base.Pre(n);
		}

		public override void Post(Root n)
		{
			base.Post(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			base.Pre(n);

			if (!(n.Parent is LocalFuncDef))
				return;

			if (!n.Locals.OfType<LocalFuncDef>().Any())
				return;

			if (n.Locals.OfType<LocalFuncDef>().Any(d => d.Locals.OfType<LocalFuncDef>().Any()))
				return;

			foreach (LocalFuncDef d in n.Locals.OfType<LocalFuncDef>())
			{
				(n.Parent as LocalFuncDef).Lift(n, d);

				madeChanges = true;
			}

			n.ClearFuncLocals();
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			n.Header.Accept(this);

			for (int i = 0; i < n.Locals.Count; i++)
			{
				n.Locals[i].Accept(this);
				i += n.Lifted;
				n.Lifted = 0;
			}

			n.Block.Accept(this);

			Post(n);
		}
	}
}
