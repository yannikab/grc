using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Ast.Visitor;
using Grc.Sem.SymbolTable;
using Grc.Sem.SymbolTable.Exceptions;
using Grc.Sem.SymbolTable.Symbol;
using Grc.Sem.Visitor.Exceptions.Sem;

namespace Grc.Sem.Visitor
{
	public class SemanticVisitor : DepthFirstVisitor
	{
		private ISymbolTable symbolTable = new StackSymbolTable();

		public ISymbolTable SymbolTable { get { return symbolTable; } }

		public override void Pre(Root n)
		{
			symbolTable.Enter();
		}

		public override void Post(Root n)
		{
			try
			{
				symbolTable.Exit();
			}
			catch (SymbolTableException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(LocalFuncDef n)
		{
			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Header.Name);

			if (symbolFunc == null || symbolFunc.ScopeId != symbolTable.CurrentScopeId)
			{
				try
				{
					symbolTable.Insert(new SymbolFunc(n.Header.Name, true));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new FunctionAlreadyInScopeException(n.Header, e);
				}
			}
			else
			{
				if (symbolFunc.Defined)
					throw new FunctionAlreadyInScopeException(n.Header, n.Header.Name);

				try
				{
					symbolTable.Insert(new SymbolFunc(n.Header.Name, true));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new FunctionAlreadyInScopeException(n.Header, e);
				}
			}
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			symbolTable.Enter();

			foreach (var p in n.Header.Parameters)
			{
				try
				{
					symbolTable.Insert(new SymbolVar(p.Name));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new VariableAlreadyInScopeException(p, e);
				}
			}

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			foreach (LocalFuncDecl d in n.Locals.OfType<LocalFuncDecl>())
			{
				SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(d.Name);

				if (symbolFunc == null)
					throw new FunctionNotInOpenScopesException(d);

				if (!symbolFunc.Defined)
					throw new FunctionDefinitionMissingException(d, symbolFunc);
			}

			n.Block.Accept(this);

			Post(n);
		}

		public override void Post(LocalFuncDef n)
		{
			try
			{
				symbolTable.Exit();
			}
			catch (NoCurrentScopeException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(LocalFuncDecl n)
		{
			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc != null && symbolFunc.ScopeId == symbolTable.CurrentScopeId)
				throw new FunctionAlreadyInScopeException(n, n.Name);

			try
			{
				symbolTable.Insert(new SymbolFunc(n.Name, false));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new FunctionAlreadyInScopeException(n, e);
			}
		}

		public override void Pre(LocalVarDef n)
		{
			foreach (Variable v in n.Variables)
			{
				try
				{
					symbolTable.Insert(new SymbolVar(v.Name));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new VariableAlreadyInScopeException(v, e);
				}
			}
		}

		public override void Pre(ExprFuncCall n)
		{
			if (symbolTable.Lookup<SymbolFunc>(n.Name) == null)
				throw new FunctionNotInOpenScopesException(n);
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			if (symbolTable.Lookup<SymbolVar>(n.Name) == null)
				throw new VariableNotInOpenScopesException(n);
		}

		public override void Pre(StmtFuncCall n)
		{
			if (symbolTable.Lookup<SymbolFunc>(n.Name) == null)
				throw new FunctionNotInOpenScopesException(n);
		}
	}
}
