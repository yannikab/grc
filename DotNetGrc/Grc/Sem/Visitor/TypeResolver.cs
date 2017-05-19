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
	class TypeResolver
	{
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

		public GTypeBase GetTypeFrom(ExprFuncCall n)
		{
			GTypeBase typeFrom = GTypeNothing.Instance;

			foreach (ExprBase a in n.Args)
			{
				if (typeFrom.Equals(GTypeNothing.Instance))
					typeFrom = a.Type;
				else
					typeFrom = new GTypeProduct(typeFrom, a.Type);
			}

			return typeFrom;
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
						throw new ArrayInvalidDimensionException(p.Dims[i]);

					parType = new GTypeIndexed(dim, parType);
				}
				catch (ArgumentNullException e)
				{
					throw new ArrayInvalidDimensionException(p.Dims[i], e);
				}
				catch (FormatException e)
				{
					throw new ArrayInvalidDimensionException(p.Dims[i], e);
				}
				catch (OverflowException e)
				{
					throw new ArrayInvalidDimensionException(p.Dims[i], e);
				}
			}

			if (p.DimEmpty != null)
				parType = new GTypeIndexed(0, parType);

			// type rule: arrays must be passed by reference
			if (parType is GTypeIndexed && !p.ByRef)
				throw new ArrayNotPassedByReferenceException(p);

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
						throw new ArrayInvalidDimensionException(v.Dims[i]);

					varType = new GTypeIndexed(dim, varType);
				}
				catch (ArgumentNullException e)
				{
					throw new ArrayInvalidDimensionException(v.Dims[i], e);
				}
				catch (FormatException e)
				{
					throw new ArrayInvalidDimensionException(v.Dims[i], e);
				}
				catch (OverflowException e)
				{
					throw new ArrayInvalidDimensionException(v.Dims[i], e);
				}
			}

			return varType;
		}

		public GTypeReturn GetType(HTypeReturn n)
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

		public GTypeBase GetType(ExprIntegerT n)
		{
			return new GTypeInt(false);
		}

		public GTypeBase GetType(ExprCharacterT n)
		{
			return new GTypeChar(false);
		}
	}
}
