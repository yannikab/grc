using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;
using Grc.Ast.Visitor;

namespace Grc.Ast.Node.Helper
{
	public class HTypePar : NodeBase
	{
		private TypeDataBase dataType;
		private DimEmptyT dimEmpty;
		private List<DimIntegerT> dims;

		public TypeDataBase DataType { get { return dataType; } }

		public DimEmptyT DimEmpty { get { return dimEmpty; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public override int Line { get { return dataType.Line; } }

		public override int Pos { get { return dataType.Pos; } }

		public HTypePar()
		{
			this.dims = new List<DimIntegerT>();
		}

		public override void AddChild(NodeBase c)
		{
			if (dataType == null)
			{
				if (c is TypeDataBase)
					dataType = (TypeDataBase)c;
				else
					throw new NodeException();
			}
			else if (dimEmpty == null)
			{
				if (c is DimEmptyT && dims.Count == 0)
					dimEmpty = (DimEmptyT)c;
				else if (c is DimIntegerT)
					dims.Add((DimIntegerT)c);
				else
					throw new NodeException();
			}
			else
			{
				if (c is DimIntegerT)
					dims.Add((DimIntegerT)c);
				else
					throw new NodeException();
			}

			base.AddChild(c);
		}

		public override void Accept(IVisitor v)
		{
			v.Visit(this);
		}

		protected override string GetText()
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(dataType.Text);

			if (dimEmpty != null)
				sb.Append(dimEmpty.Text);

			foreach (var d in dims)
				sb.Append(d.Text);

			return sb.ToString();
		}

		public override string ToString()
		{
			return "type";
		}
	}
}
