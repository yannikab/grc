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
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Ast.Node.Type;
using Grc.Semantic.Visitor.Exceptions;

namespace Grc.Semantic.Visitor
{
	public class SemanticVisitor : DepthFirstVisitor
	{
		private ISymbolTable symbolTable = new StackSymbolTable();

		protected ISymbolTable SymbolTable { get { return symbolTable; } }

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
			try
			{
				SymbolFunc sf = symbolTable.Lookup<SymbolFunc>(n.Header.Name);

				if (!sf.Defined)
				{
					sf.Defined = true;

					symbolTable.Enter();

					return;
				}
			}
			catch (SymbolNotInScopeException)
			{
			}
			catch (NoCurrentScopeException e)
			{
				throw new SemanticException(e);
			}
			catch (NullReferenceException e)
			{
				throw new SemanticException(e);
			}

			try
			{
				symbolTable.Insert(new SymbolFunc(n.Header.Name, true));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new FunctionAlreadyInScopeException(n.Header, e);
			}

			symbolTable.Enter();
		}

		public override void Post(LocalFuncDef n)
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

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			try
			{
				foreach (var p in n.Header.Parameters)
					symbolTable.Insert(new SymbolVar(p.Name));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new VariableAlreadyInScopeException(n, e);
			}

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			foreach (LocalFuncDecl d in n.Locals.OfType<LocalFuncDecl>())
			{
				try
				{
					SymbolFunc sf = symbolTable.Lookup<SymbolFunc>(d.Name);

					if (!sf.Defined)
						throw new FunctionDefinitionMissingException(d, sf);
				}
				catch (SymbolNotInScopeException e)
				{
					throw new FunctionNotInScopeException(d, e);
				}
				catch (NoCurrentScopeException e)
				{
					throw new SemanticException(e);
				}
				catch (NullReferenceException e)
				{
					throw new SemanticException(e);
				}
			}

			n.Block.Accept(this);

			Post(n);
		}

		public override void Pre(LocalFuncDecl n)
		{
			try
			{
				symbolTable.Insert(new SymbolFunc(n.Name, false));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new FunctionAlreadyInScopeException(n, e);
			}

			try
			{
				foreach (var p in n.Parameters)
					symbolTable.Insert(new SymbolVar(p.Name));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new VariableAlreadyInScopeException(n, e);
			}
		}

		public override void Pre(LocalVarDef n)
		{
			try
			{
				foreach (Variable v in n.Variables)
					symbolTable.Insert(new SymbolVar(v.Name));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new VariableAlreadyInScopeException(n, e);
			}
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			try
			{
				symbolTable.Lookup<SymbolVar>(n.Name);
			}
			catch (SymbolNotInScopeException e)
			{
				throw new VariableNotInScopeException(n, e);
			}
			catch (NoCurrentScopeException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(StmtFuncCall n)
		{
			try
			{
				symbolTable.Lookup<SymbolFunc>(n.Name);
			}
			catch (SymbolNotInScopeException e)
			{
				throw new FunctionNotInScopeException(n, e);
			}
			catch (NoCurrentScopeException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(ExprFuncCall n)
		{
			try
			{
				symbolTable.Lookup<SymbolFunc>(n.Name);
			}
			catch (SymbolNotInScopeException e)
			{
				throw new FunctionNotInScopeException(n, e);
			}
			catch (NoCurrentScopeException e)
			{
				throw new SemanticException(e);
			}
		}
	}
}
