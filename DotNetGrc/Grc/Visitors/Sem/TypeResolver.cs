using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Types;
using Grc.Nodes;
using Grc.Nodes.Expr;
using Grc.Nodes.Func;
using Grc.Nodes.Helper;
using Grc.Types;

namespace Grc.Visitors.Sem
{
	class TypeResolver
	{
		public TypeFunction GetType(LocalFuncDecl n)
		{
			TypeBase fromType = TypeNothing.Instance;

			foreach (Parameter p in n.Parameters)
			{
				TypeBase parType = GetType(p);

				if (TypeNothing.Instance.Equals(fromType))
					fromType = parType;
				else
					fromType = new TypeProduct(fromType, parType);
			}

			TypeReturn toType = GetType(n.HTypeReturn);

			return new TypeFunction(fromType, toType);
		}

		public TypeBase GetTypeFrom(ExprFuncCall n)
		{
			TypeBase typeFrom = TypeNothing.Instance;

			foreach (ExprBase a in n.Args)
			{
				if (typeFrom.Equals(TypeNothing.Instance))
					typeFrom = a.Type;
				else
					typeFrom = new TypeProduct(typeFrom, a.Type);
			}

			return typeFrom;
		}

		public TypeBase GetType(Parameter p)
		{
			TypeBase parType = null;

			if (p.Type is Grc.Nodes.Type.TypeDataIntT)
				parType = new TypeInt() { ByRef = p.Indexed ? false : p.ByRef };
			else if (p.Type is Grc.Nodes.Type.TypeDataCharT)
				parType = new TypeChar() { ByRef = p.Indexed ? false : p.ByRef };
			else
				throw new TypeException("Invalid parameter type.");

			for (int i = p.Dims.Count - 1; i >= 0; i--)
			{
				try
				{
					int dim = int.Parse(p.Dims[i].Integer);

					if (!(dim > 0))
						throw new ArrayInvalidDimensionException(p.Dims[i]);

					parType = new TypeIndexed(dim, parType) { InHeader = true };
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
				parType = new TypeIndexed(0, parType) { InHeader = true };

			// type rule: arrays must be passed by reference
			if (parType is TypeIndexed && !p.ByRef)
				throw new ArrayNotPassedByReferenceException(p);

			return parType;
		}

		public TypeBase GetType(Variable v)
		{
			TypeBase varType = null;

			if (v.Type is Grc.Nodes.Type.TypeDataIntT)
				varType = new TypeInt();
			else if (v.Type is Grc.Nodes.Type.TypeDataCharT)
				varType = new TypeChar();
			else
				throw new TypeException("Invalid variable type.");

			for (int i = v.Dims.Count - 1; i >= 0; i--)
			{
				try
				{
					int dim = int.Parse(v.Dims[i].Integer);

					if (!(dim > 0))
						throw new ArrayInvalidDimensionException(v.Dims[i]);

					varType = new TypeIndexed(dim, varType) { InHeader = false };
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

		public TypeReturn GetType(HTypeReturn n)
		{
			TypeReturn returnType;

			if (n.ReturnType is Grc.Nodes.Type.TypeReturnNothingT)
				returnType = TypeNothing.Instance;
			else if (n.ReturnType is Grc.Nodes.Type.TypeDataIntT)
				returnType = new TypeInt();
			else if (n.ReturnType is Grc.Nodes.Type.TypeDataCharT)
				returnType = new TypeChar();
			else
				throw new TypeException("Invalid return type.");

			return returnType;
		}
	}
}
