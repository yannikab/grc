using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Type;
using Grc.Visitors.Ast;

namespace Grc.Nodes.Helper
{
	public class HTypeVar : NodeBase
	{
		private readonly TypeDataBase dataType;
		private readonly List<DimIntegerT> dims;

		public TypeDataBase DataType { get { return dataType; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public override int Line { get { return dataType.Line; } }

		public override int Pos { get { return dataType.Pos; } }

		public HTypeVar(TypeDataBase dataType, List<DimIntegerT> dims)
		{
			this.dataType = dataType;
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
