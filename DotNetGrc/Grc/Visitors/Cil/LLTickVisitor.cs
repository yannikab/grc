using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Symbols;
using Grc.Visitors.Tac;

namespace Grc.Visitors.Cil
{
	class LLTickVisitor : ScopeTypeVisitor
	{
		private Stack<LocalFuncDef> localFuncDefs = new Stack<LocalFuncDef>();

		public bool MadeChanges { get; private set; }

		public override void Pre(Root n)
		{
			MadeChanges = false;

			base.Pre(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			base.Pre(n);

			this.localFuncDefs.Push(n);
		}

		public override void Post(LocalFuncDef n)
		{
			var q = from f in n.Locals.OfType<LocalFuncDef>()
					where f.Locals.OfType<LocalFuncDef>().Any() == false
					select new
					{
						FuncDef = f,

						FuncCalls = (from c in n.FuncCalls
									 where c.Name.Equals(f.Header.Name)
									 select c),

						SymbolGroups = (from s in SymbolTable.LookupAll<SymbolVar>(0)
										where s.Users.Contains(f)
										group s by s.Type into g
										select new
										{
											Type = g.Key,
											Names = g.Select(s => s.Name)
										})
					};

			foreach (var a in q)
			{
				foreach (var g in a.SymbolGroups)
				{
					MadeChanges = true;

					a.FuncDef.Header.AddParameters(g.Type, g.Names);

					var decl = n.Locals.OfType<LocalFuncDecl>().FirstOrDefault(d => d.Name == a.FuncDef.Header.Name);

					if (decl != null && decl != a.FuncDef.Header)
						decl.AddParameters(g.Type, g.Names);
				}

				foreach (var c in a.FuncCalls)
					foreach (var g in a.SymbolGroups)
						c.AddArgs(g.Names);
			}

			this.localFuncDefs.Pop();

			n.ClearFuncCalls();

			base.Post(n);
		}

		public override void Post(ExprLValIdentifierT n)
		{
			base.Post(n);

			SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(n.Name);

			if (symbolVar.ScopeId == SymbolTable.CurrentScopeId - 1)
				symbolVar.AddUser(localFuncDefs.Peek());
		}

		public override void Post(ExprFuncCall n)
		{
			base.Post(n);

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc.ScopeId == SymbolTable.CurrentScopeId - 1)
				localFuncDefs.Peek().AddCallToParent(n);
			else if (symbolFunc.ScopeId == SymbolTable.CurrentScopeId)
				localFuncDefs.Peek().AddCallToSelf(n);
		}
	}
}
