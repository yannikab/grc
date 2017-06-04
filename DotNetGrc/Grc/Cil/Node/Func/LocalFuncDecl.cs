using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Helper;
using Grc.Ast.Node.Type;
using Grc.Cil.Exceptions;
using Grc.Sem.Types;

namespace Grc.Ast.Node.Func
{
	public partial class LocalFuncDecl : LocalBase
	{
		public void AddParameters(GTypeBase type, IEnumerable<string> names)
		{
			List<ParIdentifierT> parameters = new List<ParIdentifierT>();

			foreach (string s in names)
				parameters.Add(new ParIdentifierT(s, 0, 0));

			HTypePar hTypePar = CreateHTypePar(type);

			HPar hPar = new HPar(parameters, hTypePar, "ref", ":", 0, 0);

			this.hPars.Add(hPar);

			this.parameters.AddRange(hPar.Parameters);
		}

		private HTypePar CreateHTypePar(GTypeBase type)
		{
			return new HTypePar(CreateType(type), CreateDimEmpty(type), CreateDims(type));
		}

		private TypeDataBase CreateType(GTypeBase type)
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

				return CreateType(typeIndexed.IndexedType);
			}

			throw new CilException("Could not determine type.");
		}

		private DimEmptyT CreateDimEmpty(GTypeBase type)
		{
			if (!(type is GTypeIndexed))
				return null;

			GTypeIndexed typeIndexed = (GTypeIndexed)type;

			return typeIndexed.Dim == 0 ? new DimEmptyT("[", "]", 0, 0) : null;
		}

		private List<DimIntegerT> CreateDims(GTypeBase type)
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
