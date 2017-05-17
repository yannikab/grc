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
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;
using Grc.Semantic.Types;
using Grc.Semantic.Visitor.Exceptions.GType;
using Grc.Semantic.Visitor.Exceptions.Semantic;
using Grc.Semantic.SymbolTable;
using Grc.Ast.Node.Cond;

namespace Grc.Semantic.Visitor
{
	public class GTypeVisitor : SemanticVisitor
	{
		private Dictionary<NodeBase, GTypeBase> typeForNode;
		private TypeResolver typeResolver;

		public GTypeVisitor(out ISymbolTable symbolTable, out Dictionary<NodeBase, GTypeBase> typeForNode)
			: base(out symbolTable)
		{
			typeForNode = new Dictionary<NodeBase, GTypeBase>();

			this.typeForNode = typeForNode;

			this.typeResolver = new TypeResolver(SymbolTable);
		}

		public override void Pre(Root n)
		{
			base.Pre(n);
		}

		public override void Post(Root n)
		{
			base.Post(n);
		}

		public override void Pre(LocalFuncDef n)
		{
			GTypeFunction funcDefType = typeResolver.GetType(n);
			typeForNode.Add(n, funcDefType);

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

					typeForNode.Add(p.ParIdentifier, symbolVar.Type);
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
				typeForNode.Add(n, symbolFunc.Type);
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

					typeForNode.Add(v.VarIdentifier, symbolVar.Type);
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
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(ExprLValIdentifierT n)
		{
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

		public override void Pre(CondAnd n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(CondOr n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(CondNot n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(CondRelOpBase n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(StmtAssign n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}

		public override void Pre(StmtFuncCall n)
		{
			typeForNode.Add(n, typeResolver.GetType(n));
		}
	}
}
