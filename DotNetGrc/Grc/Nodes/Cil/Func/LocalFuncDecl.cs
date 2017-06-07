using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Exceptions.Cil;
using Grc.Nodes.Helper;
using Grc.Nodes.Type;
using Grc.Types;

namespace Grc.Nodes.Func
{
	public partial class LocalFuncDecl : LocalBase
	{
		public void AddParameters(TypeBase type, IEnumerable<string> names)
		{
			List<ParIdentifierT> parameters = new List<ParIdentifierT>();

			foreach (string s in names)
				parameters.Add(new ParIdentifierT(s, 0, 0));

			HTypePar hTypePar = CreateHTypePar(type);

			HPar hPar = new HPar(parameters, hTypePar, "ref", ":", 0, 0);

			this.hPars.Add(hPar);

			this.parameters.AddRange(hPar.Parameters);
		}

		private HTypePar CreateHTypePar(TypeBase type)
		{
			return new HTypePar(CreateType(type), CreateDimEmpty(type), CreateDims(type));
		}

		private TypeDataBase CreateType(TypeBase type)
		{
			if (type is TypeInt)
				return new TypeDataIntT("int", 0, 0);
			else if (type is TypeChar)
				return new TypeDataCharT("char", 0, 0);
			else if (type is TypeIndexed)
			{
				TypeIndexed typeIndexed = type as TypeIndexed;

				while (typeIndexed.IndexedType is TypeIndexed)
					typeIndexed = (TypeIndexed)typeIndexed.IndexedType;

				return CreateType(typeIndexed.IndexedType);
			}

			throw new CilException("Could not determine type.");
		}

		private DimEmptyT CreateDimEmpty(TypeBase type)
		{
			if (!(type is TypeIndexed))
				return null;

			TypeIndexed typeIndexed = (TypeIndexed)type;

			return typeIndexed.Dim == 0 ? new DimEmptyT("[", "]", 0, 0) : null;
		}

		private List<DimIntegerT> CreateDims(TypeBase type)
		{
			List<DimIntegerT> dims = new List<DimIntegerT>();

			if (!(type is TypeIndexed))
				return dims;

			if ((type as TypeIndexed).Dim == 0)
				type = (type as TypeIndexed).IndexedType;

			while (type is TypeIndexed)
			{
				dims.Add(new DimIntegerT((type as TypeIndexed).Dim.ToString(), "[", "]", 0, 0));
				type = (type as TypeIndexed).IndexedType;
			}

			return dims;
		}
	}
}
