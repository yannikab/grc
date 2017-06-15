using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Visitors.Ast;

namespace Grc.Visitors.Cil
{
	class LLBoomVisitor : DepthFirstVisitor
	{
		public bool MadeChanges { get; private set; }

		public override void Pre(Root n)
		{
			MadeChanges = false;

			base.Pre(n);
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

				MadeChanges = true;
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
