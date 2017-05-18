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

		protected ISymbolTable SymbolTable { get { return symbolTable; } }

		public GTypeVisitor(out ISymbolTable symbolTable)
		{
			symbolTable = new StackSymbolTable();

			this.symbolTable = symbolTable;

			this.typeResolver = new TypeResolver();
		}

		public override void Pre(Root n)
		{
			symbolTable.Enter();

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

			if (symbolTable.CurrentScopeId == 0)
			{
				// type rule: main function can not have parameters
				if (!funcDefType.From.Equals(GTypeNothing.Instance))
					throw new MainFunctionWithParametersException(n.Header);

				// type rule: main function must have nothing return type
				if (!funcDefType.To.Equals(GTypeNothing.Instance))
					throw new MainFunctionWithReturnValueException(n.Header);
			}

			n.Type = funcDefType;

			try
			{
				SymbolFunc symbolFunc = SymbolTable.Lookup<SymbolFunc>(n.Header.Name);

				if (symbolFunc.ScopeId == SymbolTable.CurrentScopeId)
				{
					if (!symbolFunc.Defined)
					{
						if (symbolFunc.Type.Equals(n.Type))
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
				SymbolFunc symbolFunc = new SymbolFunc(n.Header.Name, true, n.Type);

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
				symbolTable.Exit();
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
				symbolTable.Insert(new SymbolFunc(n.Name, false, (n.Type = typeResolver.GetType(n))));
			}
			catch (SymbolAlreadyInScopeException e)
			{
				throw new FunctionAlreadyInScopeException(n, e);
			}
		}

		public override void Pre(LocalVarDef n)
		{
			//n.Type = typeResolver.GetType(n);

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

		public override void Post(ExprCharacterT n)
		{
			n.Type = typeResolver.GetType(n);
		}

		public override void Post(ExprBinOpBase n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Left.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Left);

			if (!(n.Right.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Right);

			n.Type = n.Left.Type;
		}

		public override void Post(ExprPlus n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Expr.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Expr);

			n.Type = n.Expr.Type;
		}

		public override void Post(ExprMinus n)
		{
			// type rule: arithmetic involves the integer type only
			if (!(n.Expr.Type is GTypeInt))
				throw new InvalidTypeInNumericExpression(n.Expr);

			n.Type = n.Expr.Type;
		}

		public override void Post(ExprFuncCall n)
		{
			try
			{
				GTypeFunction declType = symbolTable.Lookup<SymbolFunc>(n.Name).Type as GTypeFunction;

				if (declType == null)
					throw new InvalidSymbolTypeException(n.Name);

				GTypeBase typeFrom = typeResolver.GetTypeFrom(n);

				// type rule: function arguments must match declaration in number and type
				if (!typeFrom.Equals(declType.From))
					throw new FunctionArgsMismatchException(n, typeFrom, declType);

				// type rule: only l-value arguments allowed for parameters passed by reference
				if (!typeFrom.MatchesRef(declType.From))
					throw new RValuePassedByReferenceException(n, typeFrom, declType);

				n.Type = declType.To;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}
		}

		public override void Post(ExprLValIdentifierT n)
		{
			try
			{
				n.Type = symbolTable.Lookup<SymbolVar>(n.Name).Type;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new VariableNotInOpenScopesException(n, e);
			}
		}

		public override void Post(ExprLValStringT n)
		{
			// type rule: string literals are of type char []
			n.Type = new GTypeIndexed(n.Text.Length - 1, new GTypeChar(true));
		}

		public override void Post(ExprLValIndexed n)
		{
			GTypeBase exprType = n.Expr.Type;

			// type rule: index expression must be of type int
			if (!(exprType is GTypeInt))
				throw new IndexNotIntegerException(n, exprType);

			GTypeBase lvalType = n.Lval.Type;

			// type rule: indexed expression must have corresponding type
			if (lvalType is GTypeIndexed)
				n.Type = (lvalType as GTypeIndexed).IndexedType;
			else
				throw new IndexingInvalidTypeException(n, lvalType);
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
				throw new InvalidRelationalOperationException(n.Left, n.Left.Type);

			if (!(n.Right.Type is GTypeInt || n.Right.Type is GTypeChar))
				throw new InvalidRelationalOperationException(n.Right, n.Right.Type);

			if (!object.Equals(n.Left.Type, n.Right.Type))
				throw new InvalidRelationalOperationException(n);

			n.Type = GTypeBoolean.Instance;
		}

		public override void Post(StmtAssign n)
		{
			// type rule: right side expression type must match the l-value type
			if (!object.Equals(n.Lval.Type, n.Expr.Type))
				throw new InvalidTypeAssignmentException(n, n.Lval.Type, n.Expr.Type);
		}

		public override void Post(StmtFuncCall n)
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

				n.Type = n.FunCall.Type;
			}
			catch (SymbolNotInOpenScopesException e)
			{
				throw new FunctionNotInSymbolTableException(n, e);
			}
		}
	}
}
