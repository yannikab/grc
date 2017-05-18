using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Cond;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Stmt;
using Grc.Sem.SymbolTable;
using Grc.Sem.SymbolTable.Exceptions;
using Grc.Sem.SymbolTable.Symbol;
using Grc.Sem.Types;
using Grc.Sem.Visitor.Exceptions.GType;
using Grc.Sem.Visitor.Exceptions.Sem;

namespace Grc.Sem.Visitor
{
	public class GTypeVisitor : SemanticVisitor
	{
		private TypeResolver typeResolver;

		public GTypeVisitor(out ISymbolTable symbolTable)
			: base(out symbolTable)
		{
			this.typeResolver = new TypeResolver(SymbolTable);
		}

		public override void Pre(Root n)
		{
			base.Pre(n);

			InjectLibraryFunctions();
		}

		private void InjectLibraryFunctions()
		{
			SymbolTable.Insert(new SymbolFunc("puti", true, new GTypeFunction(new GTypeInt(false), GTypeNothing.Instance)));
			SymbolTable.Insert(new SymbolFunc("putc", true, new GTypeFunction(new GTypeChar(false), GTypeNothing.Instance)));
			SymbolTable.Insert(new SymbolFunc("puts", true, new GTypeFunction(new GTypeIndexed(0, new GTypeChar(true)), GTypeNothing.Instance)));

			SymbolTable.Insert(new SymbolFunc("geti", true, new GTypeFunction(GTypeNothing.Instance, new GTypeInt(false))));
			SymbolTable.Insert(new SymbolFunc("getc", true, new GTypeFunction(GTypeNothing.Instance, new GTypeChar(false))));
			SymbolTable.Insert(new SymbolFunc("gets", true, new GTypeFunction(new GTypeProduct(new GTypeInt(false), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance)));

			SymbolTable.Insert(new SymbolFunc("abs", true, new GTypeFunction(new GTypeInt(false), new GTypeInt(false))));
			SymbolTable.Insert(new SymbolFunc("ord", true, new GTypeFunction(new GTypeChar(false), new GTypeInt(false))));
			SymbolTable.Insert(new SymbolFunc("chr", true, new GTypeFunction(new GTypeInt(false), new GTypeChar(false))));

			SymbolTable.Insert(new SymbolFunc("strlen", true, new GTypeFunction(new GTypeIndexed(0, new GTypeChar(true)), new GTypeInt(false))));
			SymbolTable.Insert(new SymbolFunc("strcmp", true, new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), new GTypeInt(false))));
			SymbolTable.Insert(new SymbolFunc("strcpy", true, new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance)));
			SymbolTable.Insert(new SymbolFunc("strcat", true, new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance)));
		}

		public override void Post(Root n)
		{
			base.Post(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			GTypeFunction funcDefType = typeResolver.GetType(n);
			n.Type = funcDefType;

			try
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Header.Name);

				if (symbolFunc.ScopeId == SymbolTable.CurrentScopeId)
				{
					if (!symbolFunc.Defined)
					{
						if (symbolFunc.Type.Equals(funcDefType))
						{
							symbolFunc.Defined = true;
							return;
						}
						else
						{
							throw new MismatchedFunctionDefinitionException(n.Header);
						}
					}
					else
					{
						throw new FunctionAlreadyInScopeException(n, symbolFunc.Name);
					}
				}
			}
			catch (SymbolNotInOpenScopesException)
			{
			}

			try
			{
				SymbolFunc symbolFunc = new SymbolFunc(n.Header.Name, true, funcDefType);

				SymbolTable.Insert(symbolFunc);
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
					SymbolVar symbolVar = new SymbolVar(p.Name, typeResolver.GetType(p));

					SymbolTable.Insert(symbolVar);

					p.ParIdentifier.Type = symbolVar.Type;
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
			base.Post(n);
		}

		public override void Pre(LocalFuncDecl n)
		{
			base.Pre(n);

			try
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

				if (symbolFunc.ScopeId != SymbolTable.CurrentScopeId)
					throw new GTypeException("Function should be in current scope.");

				if (symbolFunc.Defined)
					throw new GTypeException("Function should not be defined.");

				symbolFunc.Type = typeResolver.GetType(n);
				n.Type = symbolFunc.Type;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}
		}

		public override void Pre(LocalVarDef n)
		{
			base.Pre(n);

			foreach (Variable v in n.Variables)
			{
				try
				{
					SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(v.Name);

					symbolVar.Type = typeResolver.GetType(v);

					v.VarIdentifier.Type = symbolVar.Type;
				}
				catch (SymbolNotInOpenScopesException e)
				{
					throw new VariableNotInSymbolTableException(v, e);
				}
			}
		}

		public override void Pre(ExprIntegerT n)
		{
			n.Type = typeResolver.GetType(n);

			try
			{
				int.Parse(n.Integer);
			}
			catch (OverflowException e)
			{
				throw new IntegerLiteralOverflowException(n, e);
			}
		}

		public override void Pre(ExprCharacterT n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprBinOpBase n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprPlus n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprMinus n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprFuncCall n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprLValStringT n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(ExprLValIndexed n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(CondAnd n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(CondOr n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(CondNot n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(CondRelOpBase n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(StmtAssign n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Pre(StmtFuncCall n)
		{
			n.Type = typeResolver.GetType(n);
		}
	}
}
