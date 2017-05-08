using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node;
using Grc.Ast.Node.Expr;
using Grc.Ast.Node.Func;
using Grc.Ast.Node.Helper;
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
				parType = GTypeInt.Instance;
			else if (p.Type is Grc.Ast.Node.Type.TypeDataCharT)
				parType = GTypeChar.Instance;
			else
				throw new GTypeException("Invalid parameter type.");

			for (int i = p.Dims.Count - 1; i >= 0; i--)
				parType = new GTypeIndexed(parType);

			// type rule: arrays must be passed by reference
			if (parType is GTypeIndexed && !p.ByRef)
				throw new IndexedNotByReferenceException(p);

			return parType;
		}

		public GTypeBase GetType(Variable v)
		{
			GTypeBase varType = null;

			if (v.Type is Grc.Ast.Node.Type.TypeDataIntT)
				varType = GTypeInt.Instance;
			else if (v.Type is Grc.Ast.Node.Type.TypeDataCharT)
				varType = GTypeChar.Instance;
			else
				throw new GTypeException("Invalid variable type.");

			for (int i = v.Dims.Count - 1; i >= 0; i--)
				varType = new GTypeIndexed(varType);

			return varType;
		}

		public GTypeBase GetType(ExprBase n)
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

		private GTypeBase GetType(ExprIntegerT n)
		{
			return GTypeInt.Instance;
		}

		private GTypeBase GetType(ExprCharacterT n)
		{
			return GTypeChar.Instance;
		}

		private GTypeBase GetType(ExprBinOpBase n)
		{
			GTypeBase typeLeft = GetType(n.Left);
			GTypeBase typeRight = GetType(n.Right);

			// type rule: arithmetic involves the integer type only
			if (!typeLeft.Equals(GTypeInt.Instance))
				throw new InvalidTypeInNumericExpression(n.Left, typeLeft);

			if (!typeRight.Equals(GTypeInt.Instance))
				throw new InvalidTypeInNumericExpression(n.Right, typeRight);

			return typeLeft;
		}

		private GTypeBase GetType(ExprPlus n)
		{
			GTypeBase typeExpr = GetType(n.Expr);

			// type rule: arithmetic involves the integer type only
			if (!typeExpr.Equals(GTypeInt.Instance))
				throw new InvalidTypeInNumericExpression(n.Expr, typeExpr);

			return typeExpr;
		}

		private GTypeBase GetType(ExprMinus n)
		{
			GTypeBase typeExpr = GetType(n.Expr);

			// type rule: arithmetic involves the integer type only
			if (!typeExpr.Equals(GTypeInt.Instance))
				throw new InvalidTypeInNumericExpression(n.Expr, typeExpr);

			return typeExpr;
		}

		public GTypeBase GetTypeFrom(ExprFuncCall n)
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

		public GTypeBase GetTypeTo(ExprFuncCall n)
		{
			try
			{
				GTypeFunction functionType = symbolTable.Lookup<SymbolFunc>(n.Name).Type as GTypeFunction;

				if (functionType == null)
					throw new GTypeException("Function lookup in symbol table yielded symbol without function type.");

				// type rule: function arguments must match declaration in number and type
				if (!functionType.From.Equals(GetTypeFrom(n)))
					throw new FunctionArgsMismatchException(n);

				return functionType.To;
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
			return new GTypeIndexed(GTypeChar.Instance);
		}

		private GTypeBase GetType(ExprLValIndexed n)
		{
			GTypeBase exprType = GetType(n.Expr);

			// type rule: index expression must be of type int
			if (!GTypeInt.Instance.Equals(exprType))
				throw new IndexNotIntegerException(n, exprType);

			GTypeBase lvalType = GetType(n.Lval);

			// type rule: indexed expression must have corresponding type
			if (lvalType is GTypeIndexed)
				return (lvalType as GTypeIndexed).IndexedType;
			else
				throw new IndexingInvalidTypeException(n, lvalType);
		}

		public GTypeFunction GetType(LocalFuncDecl n)
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

		private GTypeReturn GetType(HTypeReturn n)
		{
			GTypeReturn returnType;

			if (n.ReturnType is Grc.Ast.Node.Type.TypeReturnNothingT)
				returnType = GTypeNothing.Instance;
			else if (n.ReturnType is Grc.Ast.Node.Type.TypeDataIntT)
				returnType = GTypeInt.Instance;
			else if (n.ReturnType is Grc.Ast.Node.Type.TypeDataCharT)
				returnType = GTypeChar.Instance;
			else
				throw new GTypeException("Invalid return type.");

			return returnType;
		}

		public GTypeFunction GetType(LocalFuncDef n)
		{
			return GetType(n.Header);
		}

		public GTypeBase GetType(LocalVarDef n)
		{
			return null;
		}
	}
}
