using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Sem;
using Grc.Exceptions.Symbols;
using Grc.Exceptions.Types;
using Grc.Nodes;
using Grc.Nodes.Cond;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Nodes.Stmt;
using Grc.Symbols;
using Grc.Types;
using Grc.Visitors.Ast;
using Grc.Visitors.Sem;

namespace Grc.Visitors.Sem
{
	public class TypeVisitor : DepthFirstVisitor
	{
		private TypeResolver typeResolver = new TypeResolver();

		private ISymbolTable symbolTable = new StackSymbolTable();

		public ISymbolTable SymbolTable { get { return symbolTable; } }

		public override void Pre(Root n)
		{
			SymbolTable.Enter();

			InjectLibraryFunctions();
		}

		protected virtual void InjectLibraryFunctions()
		{
			SymbolTable.Insert(new SymbolFunc("puti", true) { Type = new TypeFunction(new TypeInt(), TypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("putc", true) { Type = new TypeFunction(new TypeChar(), TypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("puts", true) { Type = new TypeFunction(new TypeIndexed(0, new TypeChar()) { InHeader = true }, TypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("geti", true) { Type = new TypeFunction(TypeNothing.Instance, new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("getc", true) { Type = new TypeFunction(TypeNothing.Instance, new TypeChar()) });
			SymbolTable.Insert(new SymbolFunc("gets", true) { Type = new TypeFunction(new TypeProduct(new TypeInt(), new TypeIndexed(0, new TypeChar()) { InHeader = true }), TypeNothing.Instance) });

			SymbolTable.Insert(new SymbolFunc("abs", true) { Type = new TypeFunction(new TypeInt(), new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("ord", true) { Type = new TypeFunction(new TypeChar(), new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("chr", true) { Type = new TypeFunction(new TypeInt(), new TypeChar()) });

			SymbolTable.Insert(new SymbolFunc("strlen", true) { Type = new TypeFunction(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("strcmp", true) { Type = new TypeFunction(new TypeProduct(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeIndexed(0, new TypeChar()) { InHeader = true }), new TypeInt()) });
			SymbolTable.Insert(new SymbolFunc("strcpy", true) { Type = new TypeFunction(new TypeProduct(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeIndexed(0, new TypeChar()) { InHeader = true }), TypeNothing.Instance) });
			SymbolTable.Insert(new SymbolFunc("strcat", true) { Type = new TypeFunction(new TypeProduct(new TypeIndexed(0, new TypeChar()) { InHeader = true }, new TypeIndexed(0, new TypeChar()) { InHeader = true }), TypeNothing.Instance) });
		}

		public override void Post(Root n)
		{
			try
			{
				SymbolTable.Exit();
			}
			catch (SymbolException e)
			{
				throw new SemanticException(e);
			}
		}

		public override void Pre(LocalFuncDef n)
		{
			TypeFunction funcDefType = typeResolver.GetType(n.Header);

			n.Type = funcDefType;

			n.Header.Type = funcDefType;

			if (SymbolTable.CurrentScopeId == 0)
			{
				// type rule: main function can not have parameters
				if (!funcDefType.From.Equals(TypeNothing.Instance))
					throw new MainFunctionWithParametersException(n.Header);

				// type rule: main function must have nothing return type
				if (!funcDefType.To.Equals(TypeNothing.Instance))
					throw new MainFunctionWithReturnValueException(n.Header);
			}

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Header.Name);

			if (symbolFunc == null || symbolFunc.ScopeId != SymbolTable.CurrentScopeId)
			{
				try
				{
					SymbolTable.Insert(new SymbolFunc(n.Header.Name, true) { Type = funcDefType });
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new FunctionAlreadyInScopeException(n.Header, e);
				}
			}
			else
			{
				if (symbolFunc.Defined)
					throw new FunctionAlreadyInScopeException(n, symbolFunc.Name);

				if (!symbolFunc.Type.Equals(funcDefType))
					throw new FunctionMismatchedDefinitionException(n.Header);

				try
				{
					SymbolTable.Insert(new SymbolFunc(n.Header.Name, true) { Type = funcDefType });
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

			SymbolTable.Enter();

			foreach (var p in n.Header.Parameters)
			{
				try
				{
					SymbolVar symbolVar = new SymbolVar(p.Name, true) { Type = typeResolver.GetType(p) };

					SymbolTable.Insert(symbolVar);

					p.Type = symbolVar.Type;
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new VariableAlreadyInScopeException(p, e);
				}
			}

			InHeaderLocals(n);

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			foreach (LocalFuncDecl d in n.Locals.OfType<LocalFuncDecl>())
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(d.Name);

				if (symbolFunc == null)
					throw new FunctionNotInOpenScopesException(d);

				if (!symbolFunc.Defined)
					throw new FunctionDefinitionMissingException(d, symbolFunc);
			}

			InLocalsBlock(n);

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

			SymbolFunc symbolFunc = SymbolTable.LookupLast<SymbolFunc>(0);

			if (symbolFunc == null || !symbolFunc.Name.Equals(n.Header.Name))
				throw new FunctionNotInOpenScopesException(n.Header);

			if (!(symbolFunc.Type is TypeFunction))
				throw new SymbolInvalidTypeException(symbolFunc.Name, symbolFunc.Type);

			TypeFunction typeFunc = (TypeFunction)symbolFunc.Type;

			if (!(typeFunc.To is TypeNothing) && !symbolFunc.Returned)
				throw new ReturnMissingInFunctionBodyException(n, symbolFunc.Name, typeFunc);
		}

		public override void Pre(LocalFuncDecl n)
		{
			TypeFunction funcDeclType = typeResolver.GetType(n);

			n.Type = funcDeclType;

			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc != null && symbolFunc.ScopeId == SymbolTable.CurrentScopeId)
				throw new FunctionAlreadyInScopeException(n, n.Name);

			try
			{
				SymbolTable.Insert(new SymbolFunc(n.Name, false) { Type = funcDeclType });
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
					SymbolTable.Insert(new SymbolVar(v.Name, false) { Type = typeResolver.GetType(v) });
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new VariableAlreadyInScopeException(v, e);
				}
			}
		}

		public override void Post(ExprIntegerT n)
		{
			n.Type = new TypeInt();

			try
			{
				int? i = n.StaticInt;
			}
			catch (OverflowException e)
			{
				throw new OverflowInIntegerExpressionException(n, e);
			}
		}

		public override void Post(ExprCharacterT n)
		{
			n.Type = new TypeChar();
		}

		public override void Post(ExprBinOpBase n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Left.Type is TypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Left);

			if (!(n.Right.Type is TypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Right);

			n.Type = new TypeInt();

			try
			{
				int? i = n.StaticInt;
			}
			catch (OverflowException e)
			{
				throw new OverflowInIntegerExpressionException(n, e);
			}
			catch (DivideByZeroException e)
			{
				throw new OverflowInIntegerExpressionException(n, e);
			}
		}

		public override void Post(ExprPlus n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Expr.Type is TypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Expr);

			n.Type = new TypeInt();

			try
			{
				int? i = n.StaticInt;
			}
			catch (OverflowException e)
			{
				throw new OverflowInIntegerExpressionException(n, e);
			}
		}

		public override void Post(ExprMinus n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Expr.Type is TypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Expr);

			n.Type = new TypeInt();

			try
			{
				int? i = n.StaticInt;
			}
			catch (OverflowException e)
			{
				throw new OverflowInIntegerExpressionException(n, e);
			}
		}

		public override void Post(ExprFuncCall n)
		{
			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInOpenScopesException(n);

			TypeFunction declType = symbolFunc.Type as TypeFunction;

			if (declType == null)
				throw new SymbolInvalidTypeException(n.Name, symbolFunc.Type);

			TypeBase typeFrom = typeResolver.GetTypeFrom(n);

			// type rule: function arguments must match declaration in number and type
			if (!typeFrom.Equals(declType.From))
				throw new FunctionCallArgsMismatchException(n, typeFrom, declType.From);

			// type rule: only l-value arguments allowed for parameters passed by reference
			if (!typeFrom.MatchesRef(declType.From))
				throw new FunctionCallRValueByReferenceException(n, typeFrom, declType.From);

			n.TypeFrom = declType.From;

			n.Type = declType.To;
		}

		public override void Post(ExprLValIdentifierT n)
		{
			SymbolVar symbolVar = SymbolTable.Lookup<SymbolVar>(n.Name);

			if (symbolVar == null)
				throw new VariableNotInOpenScopesException(n);

			n.Type = symbolVar.Type.Clone();

			n.Type.ByRef = true;

			if (n.Type is TypeIndexed)
				((TypeIndexed)n.Type).InHeader = false;

			n.IsPar = symbolVar.IsPar;

			n.IsParByRef = symbolVar.Type.ByRef;
		}

		public override void Post(ExprLValStringT n)
		{
			// type rule: string literals are of type char []
			n.Type = new TypeIndexed(n.Text.Substring(1, n.Text.Length - 2).Length + 1, new TypeChar()) { InHeader = false };
		}

		public override void Post(ExprLValIndexed n)
		{
			// type rule: index expression must be of type int
			if (!(n.Expr.Type is TypeInt))
				throw new ArrayIndexNotIntegerException(n);

			// type rule: indexed expression must have corresponding type
			if (!(n.Lval.Type is TypeIndexed))
				throw new LValueNotIndexedTypeException(n);

			TypeIndexed lvalType = (TypeIndexed)n.Lval.Type;

			n.Type = lvalType.IndexedType.Clone();

			n.Type.ByRef = true;

			if (n.Type is TypeIndexed)
				((TypeIndexed)n.Type).InHeader = false;

			// type rule: integer indices that are known at compile time must be within array bounds
			try
			{
				if (n.Expr.StaticInt.HasValue && lvalType.Dim > 0)
				{
					int v = n.Expr.StaticInt.Value;

					if (v < 0 || v >= lvalType.Dim)
						throw new ArrayInvalidDimensionException(n, n.Expr);
				}
			}
			catch (OverflowException e)
			{
				throw new ArrayInvalidDimensionException(n, n.Expr, e);
			}
		}

		public override void Post(CondAnd n)
		{
			// type rule: conditions involve the boolean type only
			if (!n.Left.Type.Equals(TypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Left);

			if (!n.Right.Type.Equals(TypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Right);

			n.Type = n.Left.Type;
		}

		public override void Post(CondOr n)
		{
			// type rule: conditions involve the boolean type only
			if (!n.Left.Type.Equals(TypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Left);

			if (!n.Right.Type.Equals(TypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Right);

			n.Type = n.Left.Type;
		}

		public override void Post(CondNot n)
		{
			// type rule: conditions involve the boolean type only
			if (!n.Cond.Type.Equals(TypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Cond);

			n.Type = n.Cond.Type;
		}

		public override void Post(CondRelOpBase n)
		{
			// type rule: relational operators involve int or char types
			if (!(n.Left.Type is TypeInt || n.Left.Type is TypeChar))
				throw new InvalidTypeInRelOpException(n, n.Left);

			if (!(n.Right.Type is TypeInt || n.Right.Type is TypeChar))
				throw new InvalidTypeInRelOpException(n, n.Right);

			if (!Equals(n.Left.Type, n.Right.Type))
				throw new InvalidTypeInRelOpException(n);

			n.Type = TypeBoolean.Instance;
		}

		public override void Post(StmtAssign n)
		{
			// type rule: right hand side expression type must match the l-value type
			if (!Equals(n.Lval.Type, n.Expr.Type))
				throw new InvalidTypeInAssignmentException(n);

			// type rule: indexed types can not be assigned to
			if (n.Lval.Type is TypeIndexed)
				throw new IndexedTypeInAssignmentException(n);
		}

		public override void Post(StmtFuncCall n)
		{
			SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInOpenScopesException(n);

			if (!(symbolFunc.Type is TypeFunction))
				throw new SymbolInvalidTypeException(n.Name, symbolFunc.Type);

			TypeFunction funDeclType = (TypeFunction)symbolFunc.Type;

			// type rule: functions in function call statements must return nothing
			if (!funDeclType.To.Equals(TypeNothing.Instance))
				throw new FunctionCallStatementWithoutNothingException(n);
		}

		public override void Post(StmtReturn n)
		{
			SymbolFunc symbolFunc = SymbolTable.LookupLast<SymbolFunc>(1);

			if (symbolFunc == null)
				throw new FunctionNotInOpenScopesException(n);

			if (!(symbolFunc.Type is TypeFunction))
				throw new SymbolInvalidTypeException(symbolFunc.Name, symbolFunc.Type);

			TypeFunction typeFunc = (TypeFunction)symbolFunc.Type;

			if (typeFunc.To is TypeNothing)
			{
				if (n.Expr != null)
					throw new ReturnValueNotAllowedException(n, symbolFunc.Name, typeFunc, n.Expr);
			}
			else
			{
				if (n.Expr == null)
					throw new ReturnWithoutExpressionException(n, symbolFunc.Name, typeFunc);

				if (!Equals(n.Expr.Type, typeFunc.To))
					throw new ReturnDifferentTypeException(n, symbolFunc.Name, typeFunc, n.Expr);

				symbolFunc.Returned = true;
			}
		}
	}
}
