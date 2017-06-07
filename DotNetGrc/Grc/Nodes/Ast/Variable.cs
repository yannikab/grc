using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grc.Nodes.Func;
using Grc.Nodes.Type;

namespace Grc.Nodes
{
	public class Variable
	{
		private readonly string name;
		private readonly TypeDataBase type;
		private readonly IReadOnlyList<DimIntegerT> dims;

		private readonly int line;
		private readonly int pos;

		public string Name { get { return name; } }

		public TypeDataBase Type { get { return type; } }

		public IReadOnlyList<DimIntegerT> Dims { get { return dims; } }

		public bool Indexed { get { return dims.Count > 0; } }

		public string Text
		{
			get
			{
				StringBuilder sb = new StringBuilder();

				sb.Append(Name);

				sb.Append(" : ");

				sb.Append(type.Text);

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

		public Variable(string name, TypeDataBase type, IReadOnlyList<DimIntegerT> dims, int line, int pos)
		{
			this.name = name;
			this.type = type;
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
