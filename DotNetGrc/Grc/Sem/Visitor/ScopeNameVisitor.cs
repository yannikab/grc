using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Sem.SymbolTable.Symbol;
using Grc.Sem.Visitor.Exceptions.GType;

namespace Grc.Sem.Visitor
{
	public class ScopeNameVisitor : GTypeVisitor
	{
		public override void Pre(Root n)
		{
			base.Pre(n);

			ProcessLibraryFunctions(n);
		}

		private void ProcessLibraryFunctions(Root n)
		{
			try
			{
				SymbolTable.Lookup<SymbolFunc>("puti").FullName = "_puti";
				SymbolTable.Lookup<SymbolFunc>("putc").FullName = "_putc";
				SymbolTable.Lookup<SymbolFunc>("puts").FullName = "_puts";

				SymbolTable.Lookup<SymbolFunc>("geti").FullName = "_geti";
				SymbolTable.Lookup<SymbolFunc>("getc").FullName = "_getc";
				SymbolTable.Lookup<SymbolFunc>("gets").FullName = "_gets";

				SymbolTable.Lookup<SymbolFunc>("abs").FullName = "_abs";
				SymbolTable.Lookup<SymbolFunc>("ord").FullName = "_ord";
				SymbolTable.Lookup<SymbolFunc>("chr").FullName = "_chr";

				SymbolTable.Lookup<SymbolFunc>("strlen").FullName = "_strlen";
				SymbolTable.Lookup<SymbolFunc>("strcmp").FullName = "_strcmp";
				SymbolTable.Lookup<SymbolFunc>("strcpy").FullName = "_strcpy";
				SymbolTable.Lookup<SymbolFunc>("strcat").FullName = "_strcat";
			}
			catch (NullReferenceException)
			{
				throw new FunctionNotInSymbolTableException(n);
			}
		}

		public override void Post(Root n)
		{
			base.Post(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			base.Pre(n);

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Header.Name);

			symbolFunc.FullName = SymbolTable.CurrentScopeId == 0 ?
				string.Format("_{0}", n.Header.Name) :
				string.Format("{0}.{1}", SymbolTable.Lookup<SymbolFunc>(1).FullName, n.Header.Name);
		}

		public override void Post(LocalFuncDef n)
		{
			foreach (LocalFuncDecl d in n.Locals.OfType<LocalFuncDecl>())
				d.ChangeName(SymbolTable.Lookup<SymbolFunc>(d.Name).FullName);
			
			base.Post(n);

			n.Header.ChangeName(SymbolTable.Lookup<SymbolFunc>(0).FullName);
		}

		public override void Pre(LocalFuncDecl n)
		{
			base.Pre(n);

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			symbolFunc.FullName = SymbolTable.CurrentScopeId == 0 ?
				string.Format("_{0}", n.Name) :
				string.Format("{0}.{1}", SymbolTable.Lookup<SymbolFunc>(1).FullName, n.Name);
		}

		public override void Post(LocalFuncDecl n)
		{
			base.Post(n);
		}

		public override void Pre(ExprFuncCall n)
		{
			base.Pre(n);
		}

		public override void Post(ExprFuncCall n)
		{
			base.Post(n);

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInSymbolTableException(n);

			n.ChangeName(symbolFunc.FullName);
		}

		public override void Pre(StmtFuncCall n)
		{
			base.Pre(n);
		}

		public override void Post(StmtFuncCall n)
		{
			base.Post(n);

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInSymbolTableException(n);

			n.ChangeName(symbolFunc.FullName);
		}
	}
}
