using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Stmt;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic.Types;
using Grc.Semantic.Visitor.Exceptions.GType;
using Grc.Semantic.Visitor.Exceptions.Semantic;

namespace Grc.Semantic.Visitor
{
	public class GTypeVisitor : SemanticVisitor
	{
		private Dictionary<NodeBase, GTypeBase> typeForNode;
		private TypeResolver typeResolver;

		public GTypeVisitor()
		{
			this.typeForNode = new Dictionary<NodeBase, GTypeBase>();
			this.typeResolver = new TypeResolver(SymbolTable);
		}

		public override void Pre(LocalFuncDef n)
		{
			if (SymbolTable.CurrentScopeId == 0)
			{
				GTypeFunction headerType = typeResolver.GetType(n);

				// type rule: main function can not have parameters
				if (!GTypeNothing.Instance.Equals(headerType.From))
					throw new MainFunctionWithParametersException(n.Header);

				// type rule: main function must have nothing return type
				if (!GTypeNothing.Instance.Equals(headerType.To))
					throw new MainFunctionWithReturnValueException(n.Header);
			}

			try
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Header.Name);

				if (symbolFunc.ScopeId == SymbolTable.CurrentScopeId)
				{
					if (symbolFunc.Defined)
						throw new FunctionAlreadyInScopeException(n, symbolFunc.Name);

					if (symbolFunc.Type.Equals(typeResolver.GetType(n.Header)))
						symbolFunc.Defined = true;
					else
						throw new MismatchedFunctionDefinitionException(n.Header);
				}
			}
			catch (SymbolNotInOpenScopesException)
			{
				try
				{
					SymbolTable.Insert(new SymbolFunc(n.Header.Name, true));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new FunctionAlreadyInScopeException(n.Header, e);
				}
			}

			try
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Header.Name);

				if (symbolFunc.ScopeId != SymbolTable.CurrentScopeId || !symbolFunc.Defined)
					throw new FunctionNotInSymbolTableException(n.Header);

				symbolFunc.Type = typeResolver.GetType(n.Header);
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n.Header, e);
			}
		}

		public override void Visit(LocalFuncDef n)
		{
			base.Visit(n);

			foreach (Parameter p in n.Header.Parameters)
			{
				try
				{
					SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(p.Name);

					if (symbolVar.ScopeId != SymbolTable.CurrentScopeId)
						throw new ParameterNotInSymbolTableException(p);

					symbolVar.Type = typeResolver.GetType(p);
				}
				catch (SymbolNotInOpenScopesException e)
				{
					throw new ParameterNotInSymbolTableException(p, e);
				}
			}

			base.Post(n);
		}

		public override void Post(LocalFuncDef n)
		{
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
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}


			foreach (Parameter p in n.Parameters)
			{
				try
				{
					SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(p.Name);

					symbolVar.Type = typeResolver.GetType(p);
				}
				catch (SymbolNotInOpenScopesException e)
				{
					throw new ParameterNotInSymbolTableException(p, e);
				}
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
				}
				catch (SymbolNotInOpenScopesException e)
				{
					throw new VariableNotInSymbolTableException(v, e);
				}
			}
		}

		public override void Pre(ExprIntegerT n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprCharacterT n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprBinOpBase n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprPlus n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprMinus n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprFuncCall n)
		{
			base.Pre(n);

			typeForNode.Add(n, typeResolver.GetTypeFrom(n));
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			base.Pre(n);

			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprLValStringT n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprLValIndexed n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(StmtAssign n)
		{
			GTypeBase lvalType = typeResolver.GetType(n.Lval);

			GTypeBase exprType = typeResolver.GetType(n.Expr);

			if (!object.Equals(lvalType, exprType))
				throw new InvalidTypeAssignmentException(n, lvalType, exprType);
		}

		public override void Pre(StmtFuncCall n)
		{
			try
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

				if (!(symbolFunc.Type is GTypeFunction))
					throw new GTypeException("Function lookup in symbol table yielded symbol without function type.");

				GTypeFunction functionType = (GTypeFunction)symbolFunc.Type;

				if (!functionType.From.Equals(typeResolver.GetTypeFrom(n.FunCall)))
					throw new FunctionArgsMismatchException(n.FunCall);

				if (!functionType.To.Equals(GTypeNothing.Instance))
					throw new FunctionCallStatementWithoutNothingException(n);
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}
		}
	}
}
