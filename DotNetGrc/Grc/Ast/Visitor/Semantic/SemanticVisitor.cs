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
using Grc.Semantic.SymbolTable;
using Grc.Semantic.SymbolTable.Exceptions;
using Grc.Semantic.SymbolTable.Symbol;

namespace Grc.Ast.Visitor.Semantic
{
	public class SemanticVisitor : DepthFirstVisitor
	{
		ISymbolTable st = new StackSymbolTable();

		public override void Pre(Root n)
		{
			st.Enter();
		}

		public override void Post(Root n)
		{
			st.Exit();
		}

		public override void Pre(LocalFuncDef n)
		{
			st.Insert(new SymbolFunc(n.Header.Name));

			st.Enter();
		}

		public override void Post(LocalFuncDef n)
		{
			st.Exit();
		}

		public override void Visit(LocalFuncDef n)
		{
			Pre(n);

			foreach (var p in n.Header.Parameters)
				st.Insert(new SymbolVar(p.Name));

			foreach (LocalBase l in n.Locals)
				l.Accept(this);

			n.Block.Accept(this);

			Post(n);
		}

		public override void Pre(LocalFuncDecl n)
		{
			st.Insert(new SymbolFunc(n.Name));

			foreach (var p in n.Parameters)
				st.Insert(new SymbolVar(p.Name));
		}

		public override void Pre(LocalVarDef n)
		{
			foreach (Variable v in n.Variables)
				st.Insert(new SymbolVar(v.Name));
		}

		public override void Pre(ExprLValIdentifierT n)
		{
			try
			{
				st.Lookup(new SymbolVar(n.Name));
			}
			catch (SymbolNotDefinedException ex)
			{
				string m = string.Format("{0}: {1} {2}", ex.GetType().Name, n.Location, ex.Message);

				throw new SymbolNotDefinedException(m, ex);
			}
		}

		public override void Pre(StmtFuncCall n)
		{
			try
			{
				st.Lookup(new SymbolFunc(n.Name));
			}
			catch (SymbolNotDefinedException ex)
			{
				string m = string.Format("{0}: {1} {2}", ex.GetType().Name, n.Location, ex.Message);

				throw new SymbolNotDefinedException(m, ex);
			}
		}

		public override void Pre(ExprFuncCall n)
		{
			try
			{
				st.Lookup(new SymbolFunc(n.Name));
			}
			catch (SymbolNotDefinedException ex)
			{
				string m = string.Format("{0}: {1} {2}", ex.GetType().Name, n.Location, ex.Message);

				throw new SymbolNotDefinedException(m, ex);
			}
		}
	}
}
