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
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic.Visitor.Exceptions.Semantic;


namespace Grc.Semantic.Visitor
{
	public class SemanticVisitor : DepthFirstVisitor
	{
		private ISymbolTable symbolTable = new StackSymbolTable();

		protected ISymbolTable SymbolTable { get { return symbolTable; } }

		public SemanticVisitor(out ISymbolTable symbolTable)
		{
			symbolTable = new StackSymbolTable();

			this.symbolTable = symbolTable;
		}

		public override void Pre(Root n)
		{
			SymbolTable.Enter();
		}

		public override void Post(Root n)
		{
			try
			{
				SymbolTable.Exit();
			}
			catch (SymbolTableException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(LocalFuncDef n)
		{
			try
			{
				SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Header.Name);

				if (symbolFunc.ScopeId == SymbolTable.CurrentScopeId)
				{
					if (!symbolFunc.Defined)
					{
						symbolFunc.Defined = true;
						return;
					}
					else
					{
						throw new FunctionAlreadyInScopeException(n.Header, n.Header.Name);
					}
				}
			}
			catch (SymbolNotInOpenScopesException)
			{

			}

			try
			{
				symbolTable.Insert(new SymbolFunc(n.Header.Name, true));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new FunctionAlreadyInScopeException(n.Header, e);
			}
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			SymbolTable.Enter();

			foreach (var p in n.Header.Parameters)
			{
				try
				{
					SymbolTable.Insert(new SymbolVar(p.Name));
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
				try
				{
					SymbolFunc sf = SymbolTable.Lookup<SymbolFunc>(d.Name);

					if (!sf.Defined)
						throw new FunctionDefinitionMissingException(d, sf);
				}
				catch (SymbolNotInOpenScopesException e)
				{
					throw new FunctionNotInOpenScopesException(d, e);
				}
			}

			n.Block.Accept(this);

			Post(n);
		}

		public override void Post(LocalFuncDef n)
		{
			try
			{
				SymbolTable.Exit();
			}
			catch (NoCurrentScopeException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(LocalFuncDecl n)
		{
			try
			{
				SymbolTable.Insert(new SymbolFunc(n.Name, false));
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
					SymbolTable.Insert(new SymbolVar(v.Name));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new VariableAlreadyInScopeException(v, e);
				}
			}
		}

		public override void Pre(ExprFuncCall n)
		{
			try
			{
				SymbolTable.Lookup<SymbolFunc>(n.Name);
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInOpenScopesException(n, e);
			}
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			try
			{
				SymbolTable.Lookup<SymbolVar>(n.Name);
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new VariableNotInOpenScopesException(n, e);
			}
		}

		public override void Pre(StmtFuncCall n)
		{
			try
			{
				SymbolTable.Lookup<SymbolFunc>(n.Name);
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInOpenScopesException(n, e);
			}
		}
	}
}
