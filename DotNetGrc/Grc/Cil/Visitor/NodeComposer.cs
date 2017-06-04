using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;
using Grc.Sem.Types;
using Grc.Cil.Exceptions;
using Grc.Ast.Node.Helper;

namespace Grc.Sem.Visitor
{
	class NodeComposer
	{
		public HTypePar ComposeHTypePar(GTypeBase type)
		{
			return new HTypePar(ComposeType(type), ComposeDimEmpty(type), ComposeDims(type));
		}

		private TypeDataBase ComposeType(GTypeBase type)
		{
			if (type is GTypeInt)
				return new TypeDataIntT("int", 0, 0);
			else if (type is GTypeChar)
				return new TypeDataCharT("char", 0, 0);
			else if (type is GTypeIndexed)
			{
				GTypeIndexed typeIndexed = type as GTypeIndexed;

				while (typeIndexed.IndexedType is GTypeIndexed)
					typeIndexed = (GTypeIndexed)typeIndexed.IndexedType;

				return ComposeType(typeIndexed.IndexedType);
			}

			throw new CilException("Could not determine type.");
		}

		private DimEmptyT ComposeDimEmpty(GTypeBase type)
		{
			if (!(type is GTypeIndexed))
				return null;

			GTypeIndexed typeIndexed = (GTypeIndexed)type;

			return typeIndexed.Dim == 0 ? new DimEmptyT("[", "]", 0, 0) : null;
		}

		private List<DimIntegerT> ComposeDims(GTypeBase type)
		{
			List<DimIntegerT> dims = new List<DimIntegerT>();

			if (!(type is GTypeIndexed))
				return dims;

			if ((type as GTypeIndexed).Dim == 0)
				type = (type as GTypeIndexed).IndexedType;

			while (type is GTypeIndexed)
			{
				dims.Add(new DimIntegerT((type as GTypeIndexed).Dim.ToString(), "[", "]", 0, 0));
				type = (type as GTypeIndexed).IndexedType;
			}

			return dims;
		}
	}
}
