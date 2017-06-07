using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Type;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Helper
{
	public class HTypePar : NodeBase
	{
		private readonly TypeDataBase dataType;
		private readonly DimEmptyT dimEmpty;
		private readonly List<DimIntegerT> dims;

		public TypeDataBase DataType { get { return dataType; } }

		public DimEmptyT DimEmpty { get { return dimEmpty; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public override int Line { get { return dataType.Line; } }

		public override int Pos { get { return dataType.Pos; } }

		public HTypePar(TypeDataBase dataType, DimEmptyT dimEmpty, List<DimIntegerT> dims)
		{
			this.dataType = dataType;
			this.dimEmpty = dimEmpty;
			this.dims = dims;
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		public override string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.Append(dataType.Text);

				if (dimEmpty != null)
					sb.Append(dimEmpty.Text);

				foreach (var d in dims)
					sb.Append(d.Text);

				return sb.ToString();
			}
		}

		public override string ToString()
		{
			return "type";
		}
	}
}
