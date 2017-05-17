using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Ast.Node.Type;
using Grc.Ast.Node.Func;

namespace Grc.Ast.Node
{
	public class Parameter
	{
		private ParIdentifierT parIdentifier;
		private bool byRef;
		private TypeDataBase type;
		private DimEmptyT dimEmpty;

		private IReadOnlyList<DimIntegerT> dims;

		private int line;
		private int pos;

		public ParIdentifierT ParIdentifier { get { return parIdentifier; } }

		public string Name { get { return parIdentifier.Text; } }

		public bool ByRef { get { return byRef; } }

		public TypeDataBase Type { get { return type; } }

		public DimEmptyT DimEmpty { get { return dimEmpty; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public bool Indexed { get { return dimEmpty != null || dims.Count > 0; } }

		public string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				if (byRef)
					sb.Append("ref ");

				sb.Append(Name);

				sb.Append(" : ");

				sb.Append(type.Text);

				if (dimEmpty != null)
					sb.Append("[]");

				foreach (DimIntegerT d in Dims)
					sb.Append(string.Format("[{0}]", d.Integer));

				return sb.ToString();
			}
		}

		public int Line { get { return line; } }

		public int Pos { get { return pos; } }

		public string Location
		{
			get { return string.Format("[{0}, {1}]", line, pos); }
		}

		public Parameter(ParIdentifierT parIdentifier, bool byRef, TypeDataBase type, DimEmptyT dimEmpty, IReadOnlyList<DimIntegerT> dims, int line, int pos)
		{
			this.parIdentifier = parIdentifier;
			this.byRef = byRef;
			this.type = type;
			this.dimEmpty = dimEmpty;
			this.dims = dims;

			this.line = line;
			this.pos = pos;
		}

		public override string ToString()
		{
			return Text;
		}
	}
}
