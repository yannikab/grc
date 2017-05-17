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
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic.Types;
using Grc.Semantic.Visitor.Exceptions.GType;
using Grc.Semantic.Visitor.Exceptions.Semantic;

namespace Grc.Semantic.Visitor
{
	class TypeResolver
	{
		private ISymbolTable symbolTable;

		public TypeResolver(ISymbolTable symbolTable)
		{
			this.symbolTable = symbolTable;
		}

		public GTypeBase GetType(Parameter p)
		{
			GTypeBase parType = null;

			if (p.Type is Grc.Ast.Node.Type.TypeDataIntT)
				parType = new GTypeInt(p.Indexed ? true : p.ByRef);
			else if (p.Type is Grc.Ast.Node.Type.TypeDataCharT)
				parType = new GTypeChar(p.Indexed ? true : p.ByRef);
			else
				throw new GTypeException("Invalid parameter type.");

			for (int i = p.Dims.Count - 1; i >= 0; i--)
			{
				try
				{
					int dim = int.Parse(p.Dims[i].Integer);

					if (!(dim > 0))
						throw new InvalidArrayDimensionException(p.Dims[i]);

					parType = new GTypeIndexed(parType, dim);
				}
				catch (ArgumentNullException e)
				{
					throw new InvalidArrayDimensionException(p.Dims[i], e);
				}
				catch (FormatException e)
				{
					throw new InvalidArrayDimensionException(p.Dims[i], e);
				}
				catch (OverflowException e)
				{
					throw new InvalidArrayDimensionException(p.Dims[i], e);
				}
			}

			if (p.DimEmpty != null)
				parType = new GTypeIndexed(parType, 0);

			// type rule: arrays must be passed by reference
			if (parType is GTypeIndexed && !p.ByRef)
				throw new IndexedNotByReferenceException(p);

			return parType;
		}

		public GTypeBase GetType(Variable v)
		{
			GTypeBase varType = null;

			if (v.Type is Grc.Ast.Node.Type.TypeDataIntT)
				varType = new GTypeInt(v.Indexed);
			else if (v.Type is Grc.Ast.Node.Type.TypeDataCharT)
				varType = new GTypeChar(v.Indexed);
			else
				throw new GTypeException("Invalid variable type.");

			for (int i = v.Dims.Count - 1; i >= 0; i--)
			{
				try
				{
					int dim = int.Parse(v.Dims[i].Integer);

					if (!(dim > 0))
						throw new InvalidArrayDimensionException(v.Dims[i]);

					varType = new GTypeIndexed(varType, dim);
				}
				catch (ArgumentNullException e)
				{
					throw new InvalidArrayDimensionException(v.Dims[i], e);
				}
				catch (FormatException e)
				{
					throw new InvalidArrayDimensionException(v.Dims[i], e);
				}
				catch (OverflowException e)
				{
					throw new InvalidArrayDimensionException(v.Dims[i], e);
				}
			}

			return varType;
		}

		public GTypeBase GetType(NodeBase n)
		{
			if (n is LocalBase)
				return GetType(n as LocalBase);
			if (n is ExprBase)
				return GetType(n as ExprBase);
			else if (n is CondBase)
				return GetType(n as CondBase);
			else
				throw new GTypeException("Invalid node type.");
		}

		public GTypeFunction GetType(LocalBase n)
		{
			if (n is LocalFuncDecl)
				return GetType(n as LocalFuncDecl);
			else if (n is LocalFuncDef)
				return GetType(n as LocalFuncDef);
			else
				throw new GTypeException("Invalid local type.");
		}

		private GTypeBase GetType(ExprBase n)
		{
			if (n is ExprIntegerT)
				return GetType(n as ExprIntegerT);
			else if (n is ExprCharacterT)
				return GetType(n as ExprCharacterT);
			else if (n is ExprBinOpBase)
				return GetType(n as ExprBinOpBase);
			else if (n is ExprPlus)
				return GetType(n as ExprPlus);
			else if (n is ExprMinus)
				return GetType(n as ExprMinus);
			else if (n is ExprFuncCall)
				return GetTypeTo(n as ExprFuncCall);
			else if (n is ExprLValBase)
				return GetType(n as ExprLValBase);
			else
				throw new GTypeException("Invalid expression type.");
		}

		private GTypeBase GetType(ExprLValBase n)
		{
			if (n is ExprLValIdentifierT)
				return GetType(n as ExprLValIdentifierT);
			else if (n is ExprLValStringT)
				return GetType(n as ExprLValStringT);
			else if (n is ExprLValIndexed)
				return GetType(n as ExprLValIndexed);
			else
				throw new GTypeException("Invalid l-value type.");
		}

		private GTypeBase GetType(CondBase n)
		{
			if (n is CondAnd)
				return GetType(n as CondAnd);
			else if (n is CondOr)
				return GetType(n as CondOr);
			else if (n is CondNot)
				return GetType(n as CondNot);
			else if (n is CondRelOpBase)
				return GetType(n as CondRelOpBase);
			else
				throw new GTypeException("Invalid condition type.");
		}

		private GTypeFunction GetType(LocalFuncDecl n)
		{
			GTypeBase fromType = GTypeNothing.Instance;

			foreach (Parameter p in n.Parameters)
			{
				GTypeBase parType = GetType(p);

				if (GTypeNothing.Instance.Equals(fromType))
					fromType = parType;
				else
					fromType = new GTypeProduct(fromType, parType);
			}

			GTypeReturn toType = GetType(n.HTypeReturn);

			return new GTypeFunction(fromType, toType);
		}

		private GTypeFunction GetType(LocalFuncDef n)
		{
			GTypeFunction funcDefType = GetType(n.Header);

			if (symbolTable.CurrentScopeId == 0)
			{
				// type rule: main function can not have parameters
				if (!funcDefType.From.Equals(GTypeNothing.Instance))
					throw new MainFunctionWithParametersException(n.Header);

				// type rule: main function must have nothing return type
				if (!funcDefType.To.Equals(GTypeNothing.Instance))
					throw new MainFunctionWithReturnValueException(n.Header);
			}

			return funcDefType;
		}

		private GTypeBase GetType(ExprIntegerT n)
		{
			return new GTypeInt(false);
		}

		private GTypeBase GetType(ExprCharacterT n)
		{
			return new GTypeChar(false);
		}

		private GTypeBase GetType(ExprBinOpBase n)
		{
			GTypeBase typeLeft = GetType(n.Left);
			GTypeBase typeRight = GetType(n.Right);

			// type rule: arithmetic involves the integer type only
			if (!(typeLeft is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Left, typeLeft);

			if (!(typeRight is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Right, typeRight);

			return typeLeft;
		}

		private GTypeBase GetType(ExprPlus n)
		{
			GTypeBase typeExpr = GetType(n.Expr);

			// type rule: arithmetic involves the integer type only
			if (!(typeExpr is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Expr, typeExpr);

			return typeExpr;
		}

		private GTypeBase GetType(ExprMinus n)
		{
			GTypeBase typeExpr = GetType(n.Expr);

			// type rule: arithmetic involves the integer type only
			if (!(typeExpr is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Expr, typeExpr);

			return typeExpr;
		}

		private GTypeBase GetTypeFrom(ExprFuncCall n)
		{
			GTypeBase typeFrom = GTypeNothing.Instance;

			foreach (ExprBase a in n.Args)
			{
				if (typeFrom.Equals(GTypeNothing.Instance))
					typeFrom = GetType(a);
				else
					typeFrom = new GTypeProduct(typeFrom, GetType(a));
			}

			return typeFrom;
		}

		private GTypeBase GetTypeTo(ExprFuncCall n)
		{
			try
			{
				GTypeFunction declType = symbolTable.Lookup<SymbolFunc>(n.Name).Type as GTypeFunction;

				if (declType == null)
					throw new InvalidSymbolTypeException(n.Name);

				GTypeBase callType = GetTypeFrom(n);

				// type rule: function arguments must match declaration in number and type
				if (!callType.Equals(declType.From))
					throw new FunctionArgsMismatchException(n, callType, declType);

				// type rule: only l-value arguments allowed for parameters passed by reference
				if (!callType.MatchesRef(declType.From))
					throw new RValuePassedByReferenceException(n, callType, declType);

				return declType.To;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}
		}

		private GTypeBase GetType(ExprLValIdentifierT n)
		{
			try
			{
				return symbolTable.Lookup<SymbolVar>(n.Name).Type;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new VariableNotInOpenScopesException(n, e);
			}
		}

		private GTypeBase GetType(ExprLValStringT n)
		{
			// type rule: string literals are of type char []
			return new GTypeIndexed(new GTypeChar(true), n.Text.Length - 1);
		}

		private GTypeBase GetType(ExprLValIndexed n)
		{
			GTypeBase exprType = GetType(n.Expr);

			// type rule: index expression must be of type int
			if (!(exprType is GTypeInt))
				throw new IndexNotIntegerException(n, exprType);

			GTypeBase lvalType = GetType(n.Lval);

			// type rule: indexed expression must have corresponding type
			if (lvalType is GTypeIndexed)
				return (lvalType as GTypeIndexed).IndexedType;
			else
				throw new IndexingInvalidTypeException(n, lvalType);
		}

		private GTypeReturn GetType(HTypeReturn n)
		{
			GTypeReturn returnType;

			if (n.ReturnType is Grc.Ast.Node.Type.TypeReturnNothingT)
				returnType = GTypeNothing.Instance;
			else if (n.ReturnType is Grc.Ast.Node.Type.TypeDataIntT)
				returnType = new GTypeInt(false);
			else if (n.ReturnType is Grc.Ast.Node.Type.TypeDataCharT)
				returnType = new GTypeChar(false);
			else
				throw new GTypeException("Invalid return type.");

			return returnType;
		}

		private GTypeBase GetType(CondAnd n)
		{
			GTypeBase typeLeft = GetType(n.Left);
			GTypeBase typeRight = GetType(n.Right);

			// type rule: conditions involve the boolean type only
			if (!typeLeft.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Left, typeLeft);

			if (!typeRight.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Right, typeRight);

			return typeLeft;
		}

		private GTypeBase GetType(CondOr n)
		{
			GTypeBase typeLeft = GetType(n.Left);
			GTypeBase typeRight = GetType(n.Right);

			// type rule: conditions involve the boolean type only
			if (!typeLeft.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Left, typeLeft);

			if (!typeRight.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Right, typeRight);

			return typeLeft;
		}

		private GTypeBase GetType(CondNot n)
		{
			GTypeBase cond = GetType(n.Cond);

			// type rule: conditions involve the boolean type only
			if (!cond.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Cond, cond);

			return cond;
		}

		private GTypeBase GetType(CondRelOpBase n)
		{
			GTypeBase typeLeft = GetType(n.Left);
			GTypeBase typeRight = GetType(n.Right);

			// type rule: relational operators involve int or char types
			if (!(typeLeft is GTypeInt || typeLeft is GTypeChar))
				throw new InvalidRelationalOperationException(n.Left, typeLeft);

			if (!(typeRight is GTypeInt || typeRight is GTypeChar))
				throw new InvalidRelationalOperationException(n.Right, typeRight);

			if (!object.Equals(typeLeft, typeRight))
				throw new InvalidRelationalOperationException(n);

			return GTypeBoolean.Instance;
		}

		public GTypeBase GetType(StmtAssign n)
		{
			GTypeBase lvalType = GetType(n.Lval);

			GTypeBase exprType = GetType(n.Expr);

			// type rule: right side expression type must match the l-value type
			if (!object.Equals(lvalType, exprType))
				throw new InvalidTypeAssignmentException(n, lvalType, exprType);

			return lvalType;
		}

		public GTypeFunction GetType(StmtFuncCall n)
		{
			try
			{
				SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Name);

				if (!(symbolFunc.Type is GTypeFunction))
					throw new InvalidSymbolTypeException(n.Name);

				GTypeFunction funDeclType = (GTypeFunction)symbolFunc.Type;

				// type rule: functions in function call statements must return nothing
				if (!funDeclType.To.Equals(GTypeNothing.Instance))
					throw new FunctionCallStatementWithoutNothingException(n);

				GTypeBase funCallType = GetTypeFrom(n.FunCall);

				// type rule: arguments must match parameters in type and number
				if (!funCallType.Equals(funDeclType.From))
					throw new FunctionArgsMismatchException(n.FunCall, funCallType, funDeclType);

				// type rule: only l-value arguments allowed for parameters passed by reference
				if (!funCallType.MatchesRef(funDeclType.From))
					throw new RValuePassedByReferenceException(n.FunCall, funCallType, funDeclType);

				return funDeclType;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}
		}
	}
}
