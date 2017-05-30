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
using Grc.Ast.Visitor;
using Grc.Sem.SymbolTable;
using Grc.Sem.SymbolTable.Exceptions;
using Grc.Sem.SymbolTable.Symbol;
using Grc.Sem.Types;
using Grc.Sem.Visitor.Exceptions.GType;
using Grc.Sem.Visitor.Exceptions.Sem;

namespace Grc.Sem.Visitor
{
	public class GTypeVisitor : DepthFirstVisitor
	{
		private ISymbolTable symbolTable;
		private TypeResolver typeResolver;

		public ISymbolTable SymbolTable { get { return symbolTable; } }

		public GTypeVisitor()
		{
			this.symbolTable = new StackSymbolTable();

			this.typeResolver = new TypeResolver();
		}

		public override void Pre(Root n)
		{
			symbolTable.Enter();

			InjectLibraryFunctions();
		}

		protected virtual void InjectLibraryFunctions()
		{
			symbolTable.Insert(new SymbolFunc("puti", true, new GTypeFunction(new GTypeInt(false), GTypeNothing.Instance)));
			symbolTable.Insert(new SymbolFunc("putc", true, new GTypeFunction(new GTypeChar(false), GTypeNothing.Instance)));
			symbolTable.Insert(new SymbolFunc("puts", true, new GTypeFunction(new GTypeIndexed(0, new GTypeChar(true)), GTypeNothing.Instance)));

			symbolTable.Insert(new SymbolFunc("geti", true, new GTypeFunction(GTypeNothing.Instance, new GTypeInt(false))));
			symbolTable.Insert(new SymbolFunc("getc", true, new GTypeFunction(GTypeNothing.Instance, new GTypeChar(false))));
			symbolTable.Insert(new SymbolFunc("gets", true, new GTypeFunction(new GTypeProduct(new GTypeInt(false), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance)));

			symbolTable.Insert(new SymbolFunc("abs", true, new GTypeFunction(new GTypeInt(false), new GTypeInt(false))));
			symbolTable.Insert(new SymbolFunc("ord", true, new GTypeFunction(new GTypeChar(false), new GTypeInt(false))));
			symbolTable.Insert(new SymbolFunc("chr", true, new GTypeFunction(new GTypeInt(false), new GTypeChar(false))));

			symbolTable.Insert(new SymbolFunc("strlen", true, new GTypeFunction(new GTypeIndexed(0, new GTypeChar(true)), new GTypeInt(false))));
			symbolTable.Insert(new SymbolFunc("strcmp", true, new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), new GTypeInt(false))));
			symbolTable.Insert(new SymbolFunc("strcpy", true, new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance)));
			symbolTable.Insert(new SymbolFunc("strcat", true, new GTypeFunction(new GTypeProduct(new GTypeIndexed(0, new GTypeChar(true)), new GTypeIndexed(0, new GTypeChar(true))), GTypeNothing.Instance)));
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
			GTypeFunction funcDefType = typeResolver.GetType(n.Header);

			n.Type = funcDefType;

			if (symbolTable.CurrentScopeId == 0)
			{
				// type rule: main function can not have parameters
				if (!funcDefType.From.Equals(GTypeNothing.Instance))
					throw new MainFunctionWithParametersException(n.Header);

				// type rule: main function must have nothing return type
				if (!funcDefType.To.Equals(GTypeNothing.Instance))
					throw new MainFunctionWithReturnValueException(n.Header);
			}

			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Header.Name);

			if (symbolFunc == null || symbolFunc.ScopeId != symbolTable.CurrentScopeId)
			{
				try
				{
					symbolTable.Insert(new SymbolFunc(n.Header.Name, true, funcDefType));
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
					symbolTable.Insert(new SymbolFunc(n.Header.Name, true, funcDefType));
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
					SymbolVar symbolVar = new SymbolVar(p.Name, typeResolver.GetType(p));

					symbolTable.Insert(symbolVar);
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
					throw new FunctionNotInOpenScopesException(d, d.Name);

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

			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(0);

			if (symbolFunc == null || !symbolFunc.Name.Equals(n.Header.Name))
				throw new FunctionNotInSymbolTableException(n);

			if (!(symbolFunc.Type is GTypeFunction))
				throw new SymbolInvalidTypeException(symbolFunc.Name, symbolFunc.Type);

			GTypeFunction typeFunc = (GTypeFunction)symbolFunc.Type;

			if (!(typeFunc.To is GTypeNothing) && !symbolFunc.Returned)
				throw new ReturnMissingInFunctionBodyException(n, symbolFunc.Name, typeFunc);
		}

		public override void Pre(LocalFuncDecl n)
		{
			GTypeFunction funcDeclType = typeResolver.GetType(n);

			n.Type = funcDeclType;

			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc != null && symbolFunc.ScopeId == symbolTable.CurrentScopeId)
				throw new FunctionAlreadyInScopeException(n, n.Name);

			try
			{
				symbolTable.Insert(new SymbolFunc(n.Name, false, funcDeclType));
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
					symbolTable.Insert(new SymbolVar(v.Name, typeResolver.GetType(v)));
				}
				catch (SymbolAlreadyInScopeException e)
				{
					throw new VariableAlreadyInScopeException(v, e);
				}
			}
		}

		public override void Post(ExprIntegerT n)
		{
			n.Type = new GTypeInt(false);

			try
			{
				int? i = n.StaticInt;
			}
			catch (OverflowException e)
			{
				throw new OverflowInIntegerLiteralException(n, e);
			}
		}

		public override void Post(ExprCharacterT n)
		{
			n.Type = new GTypeChar(false);
		}

		public override void Post(ExprBinOpBase n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Left.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Left);

			if (!(n.Right.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Right);

			n.Type = new GTypeInt(false);
		}

		public override void Post(ExprPlus n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Expr.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Expr);

			n.Type = new GTypeInt(false);
		}

		public override void Post(ExprMinus n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Expr.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n, n.Expr);

			n.Type = new GTypeInt(false);
		}

		public override void Post(ExprFuncCall n)
		{
			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInSymbolTableException(n);

			GTypeFunction declType = symbolFunc.Type as GTypeFunction;

			if (declType == null)
				throw new SymbolInvalidTypeException(n.Name, symbolFunc.Type);

			GTypeBase typeFrom = typeResolver.GetTypeFrom(n);

			// type rule: function arguments must match declaration in number and type
			if (!typeFrom.Equals(declType.From))
				throw new FunctionCallArgsMismatchException(n, typeFrom, declType.From);

			// type rule: only l-value arguments allowed for parameters passed by reference
			if (!typeFrom.MatchesRef(declType.From))
				throw new FunctionCallRValueByReferenceException(n, typeFrom, declType.From);

			n.Type = declType.To;
		}

		public override void Post(ExprLValIdentifierT n)
		{
			SymbolVar symbolVar = symbolTable.Lookup<SymbolVar>(n.Name);

			if (symbolVar == null)
				throw new VariableNotInOpenScopesException(n, n.Name);

			// quick solution, a better one would be to clone the type
			if (symbolVar.Type is GTypeInt)
				n.Type = new GTypeInt(true);
			else if (symbolVar.Type is GTypeChar)
				n.Type = new GTypeChar(true);
			else
				n.Type = symbolVar.Type;
		}

		public override void Post(ExprLValStringT n)
		{
			// type rule: string literals are of type char []
			n.Type = new GTypeIndexed(n.Text.Length - 1, new GTypeChar(true));
		}

		public override void Post(ExprLValIndexed n)
		{
			// type rule: index expression must be of type int
			if (!(n.Expr.Type is GTypeInt))
				throw new ArrayIndexNotIntegerException(n);

			// type rule: indexed expression must have corresponding type
			if (!(n.Lval.Type is GTypeIndexed))
				throw new LValueNotIndexedTypeException(n);

			GTypeIndexed lvalType = (GTypeIndexed)n.Lval.Type;

			n.Type = lvalType.IndexedType;

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
			if (!n.Left.Type.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Left);

			if (!n.Right.Type.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Right);

			n.Type = n.Left.Type;
		}

		public override void Post(CondOr n)
		{
			// type rule: conditions involve the boolean type only
			if (!n.Left.Type.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Left);

			if (!n.Right.Type.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Right);

			n.Type = n.Left.Type;
		}

		public override void Post(CondNot n)
		{
			// type rule: conditions involve the boolean type only
			if (!n.Cond.Type.Equals(GTypeBoolean.Instance))
				throw new InvalidTypeInConditionException(n.Cond);

			n.Type = n.Cond.Type;
		}

		public override void Post(CondRelOpBase n)
		{
			// type rule: relational operators involve int or char types
			if (!(n.Left.Type is GTypeInt || n.Left.Type is GTypeChar))
				throw new InvalidTypeInRelOpException(n, n.Left);

			if (!(n.Right.Type is GTypeInt || n.Right.Type is GTypeChar))
				throw new InvalidTypeInRelOpException(n, n.Right);

			if (!object.Equals(n.Left.Type, n.Right.Type))
				throw new InvalidTypeInRelOpException(n);

			n.Type = GTypeBoolean.Instance;
		}

		public override void Post(StmtAssign n)
		{
			// type rule: right hand side expression type must match the l-value type
			if (!object.Equals(n.Lval.Type, n.Expr.Type))
				throw new InvalidTypeInAssignmentException(n);

			// type rule: indexed types can not be assigned to
			if (n.Lval.Type is GTypeIndexed)
				throw new IndexedTypeInAssignmentException(n);
		}

		public override void Post(StmtFuncCall n)
		{
			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(n.Name);

			if (symbolFunc == null)
				throw new FunctionNotInSymbolTableException(n);

			if (!(symbolFunc.Type is GTypeFunction))
				throw new SymbolInvalidTypeException(n.Name, symbolFunc.Type);

			GTypeFunction funDeclType = (GTypeFunction)symbolFunc.Type;

			// type rule: functions in function call statements must return nothing
			if (!funDeclType.To.Equals(GTypeNothing.Instance))
				throw new FunctionCallStatementWithoutNothingException(n);
		}

		public override void Post(StmtReturn n)
		{
			SymbolFunc symbolFunc = symbolTable.Lookup<SymbolFunc>(1);

			if (symbolFunc == null)
				throw new FunctionNotInSymbolTableException(n);

			if (!(symbolFunc.Type is GTypeFunction))
				throw new SymbolInvalidTypeException(symbolFunc.Name, symbolFunc.Type);

			GTypeFunction typeFunc = (GTypeFunction)symbolFunc.Type;

			if (typeFunc.To is GTypeNothing)
			{
				if (n.Expr != null)
					throw new ReturnValueNotAllowedException(n, symbolFunc.Name, typeFunc, n.Expr);
			}
			else
			{
				if (n.Expr == null)
					throw new ReturnWithoutExpressionException(n, symbolFunc.Name, typeFunc);

				if (!object.Equals(n.Expr.Type, typeFunc.To))
					throw new ReturnDifferentTypeException(n, symbolFunc.Name, typeFunc, n.Expr);

				symbolFunc.Returned = true;
			}
		}
	}
}
